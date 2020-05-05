Shader "Holistic/Outline"
{

    Properties
    {
        _Amount("Amount", Range(0, 10)) = 0
        _MainTex("Main Texture", 2D) = "white" {}
        _OutlineCol("Outline Color", Color) = (0, 0, 0, 0)
    }
    
    SubShader
    {
    
        ZWrite Off
    
        CGPROGRAM
            #pragma surface surf Lambert vertex:vert
            
            struct Input
            {
                float2 uv_MainTex;
            };
            
            sampler2D _MainTex;
            float _Amount;
            float4 _OutlineCol;
            
            void vert(inout appdata_full v)
            {
                v.vertex.xyz += v.normal * _Amount;
            }
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                o.Emission = _OutlineCol.rgb;
            }
        ENDCG
        
        ZWrite On
        
        CGPROGRAM
            #pragma surface surf Lambert
            
            struct Input
            {
                float2 uv_MainTex;
            };
            
            sampler2D _MainTex;
            float4 _OutlineCol;
            float _Amount;
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = tex2D(_MainTex, IN.uv_MainTex);
            }
            
        ENDCG
    }
    
    Fallback "Diffuse"

}