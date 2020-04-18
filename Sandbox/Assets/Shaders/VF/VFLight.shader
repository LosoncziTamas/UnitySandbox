Shader "Holistic/VFLight"
{
    Properties
    {
        _MainTexture("Main Texture", 2D) = "white" {}
    }
    
    Subshader
    {
        Tags {"LightMode" = "ForwardBase"}
        
        Pass
        {
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                
                #include "UnityLightingCommon.cginc"
                #include "UnityCG.cginc"
                
                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv: TEXCOORD0;
                };
                
                struct v2f
                {
                    float4 vertex: SV_POSITION;
                    float4 diffuse: COLOR;
                    float2 uv : TEXCOORD0;
                    
                };
                
                sampler2D _MainTexture;
                float4 _MainTexture_ST;
                
                v2f vert(appdata i)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(i.vertex);
                    o.uv = TRANSFORM_TEX(i.uv, _MainTexture);
                    float3 normal = UnityObjectToWorldNormal(i.normal);
                    float result = max(0, dot(normal, _WorldSpaceLightPos0));
                    o.diffuse = _LightColor0 * result;
                    return o;
                }
                
                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 color = tex2D(_MainTexture, i.uv) * i.diffuse;
                    return color;
                }
                
            ENDCG
        }
    }
}