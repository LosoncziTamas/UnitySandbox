Shader "Holistic/VFChallenge2"
{
    Properties
    {
        _MainTexture ("Main Texture", 2D) = "white" {}
    }
    
    SubShader
    {
        Pass
        {
            Tags {"LightMode" = "ForwardBase"}
        
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                
                #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
                
                #include "UnityLightingCommon.cginc"
                #include "UnityCG.cginc"
                #include "Lighting.cginc" 
                #include "AutoLight.cginc"
                
                struct appdata
                {
                    float4 vertex: POSITION;
                    float3 normal : NORMAL;
                    float4 uv: TEXCOORD0;
                };
                
                struct v2f
                {
                    float2 uv: TEXCOORD0;
                    SHADOW_COORDS(1)
                    float4 pos: SV_POSITION;
                    float4 diffuse: COLOR;
                };
                
                sampler2D _MainTexture;
                
                v2f vert(appdata v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    float3 normal = UnityObjectToWorldNormal(v.normal);
                    float result = max(0, dot(normal, _WorldSpaceLightPos0));
                    o.diffuse = _LightColor0 * result;
                    TRANSFER_SHADOW(o);
                    return o;
                }
                
                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 color = tex2D(_MainTexture, i.uv);
                    fixed shadow = SHADOW_ATTENUATION(i);
                    // (1.0 = fully lit, 0.0 = fully shadowed)
                    float3 extraRed = 0;
                    if (shadow < 0.2)
                    {
                        extraRed.r = 1.0f;
                    }
                    color.rgb *= i.diffuse + extraRed;
                    return color;
                }
            ENDCG
        }
        
        Pass
        {
            Tags {"LightMode" = "ShadowCaster"}
            
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_shadowcaster
                
                #include "UnityCG.cginc"
                
                struct v2f 
                {
                    V2F_SHADOW_CASTER;
                };
                
                struct appdata
                {
                    float4 vertex: POSITION;
                    float3 normal : NORMAL;
                    float4 uv: TEXCOORD0;
                };
                
                v2f vert(appdata v)
                {
                    v2f o;
                    TRANSFER_SHADOW_CASTER_NORMALOFFSET(o);
                    return o;
                }
                
                fixed4 frag(v2f i) : SV_Target
                {
                    SHADOW_CASTER_FRAGMENT(i);
                }
                
            ENDCG
        }
    }
}