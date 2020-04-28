Shader "Holistic/Extrude"
{
    Properties 
    {
        _MainTex ("Main texture", 2D) = "white" {}
        _Amount ("Amount", Range(-1, 10)) = 0
    }
    
    Subshader
    {
        CGPROGRAM
            #pragma surface surf Lambert vertex:vert
            
            struct Input
            {
                float2 uv_MainTex;
                float3 normal;
                float4 vertex;
            };
            
            struct appdata
            {
                float4 vertex: POSITION;
                float3 normal: NORMAL;
                float2 texcoord: TEXCOORD0;
            };
            
            sampler2D _MainTex;
            float _Amount;
                        
            void vert(inout appdata v)
            {
                v.vertex.xyz = v.vertex.xyz + v.normal * _Amount;
            }
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
            }
            
        ENDCG
    }
    
    Fallback "Diffuse"
}