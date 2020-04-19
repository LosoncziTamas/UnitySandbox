Shader "Holistic/VFLight"
{
    Properties
    {
        _MainTexture("Main Texture", 2D) = "white" {}
    }
    
    Subshader
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
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv: TEXCOORD0;
                };
                
                struct v2f
                {
                    float4 pos: SV_POSITION;
                    float4 diffuse: COLOR;
                    float2 uv : TEXCOORD0;
                    SHADOW_COORDS(1)
                };
                
                sampler2D _MainTexture;
                float4 _MainTexture_ST;
                
                v2f vert(appdata i)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(i.vertex);
                    o.uv = TRANSFORM_TEX(i.uv, _MainTexture);
                    float3 normal = UnityObjectToWorldNormal(i.normal);
                    float result = max(0, dot(normal, _WorldSpaceLightPos0));
                    o.diffuse = _LightColor0 * result;
                    TRANSFER_SHADOW(o);
                    return o;
                }
                
                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 color = tex2D(_MainTexture, i.uv);
                    fixed shadow = SHADOW_ATTENUATION(i);
                    color.rgb *= i.diffuse * shadow;
                    return color;
                }
                
            ENDCG
        }
        
        Pass
        {
            Tags {"LightMode"="ShadowCaster"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"
            
            struct appdata 
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f 
            { 
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i);
            }
            ENDCG
        }
    }
}