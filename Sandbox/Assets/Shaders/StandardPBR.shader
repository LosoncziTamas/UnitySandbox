Shader "Holistic/StandardPBR"
{
    Properties 
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _MetallicTex ("Metallic (R)", 2D) = "white" {}
        _Metallic ("Metallic", Range(0, 1)) = 0.5
        _Emission ("Emission", Range(0, 10)) = 0.5
    }
    
    SubShader 
    {
        CGPROGRAM
        #pragma surface surf Standard
        
        sampler2D _MetallicTex;
        half _Metallic;
        half _Emission;
        fixed4 _Color;
        
        struct Input
        {
            float2 uv_MetallicTex;
        };
        
        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            o.Metallic = _Metallic;
            o.Smoothness = tex2D(_MetallicTex, IN.uv_MetallicTex).r;
            o.Albedo = _Color.rgb;
            o.Emission = tex2D(_MetallicTex, IN.uv_MetallicTex).rgb * _Emission;
        }
            
        ENDCG
    }
    
     Fallback "Diffuse"
}