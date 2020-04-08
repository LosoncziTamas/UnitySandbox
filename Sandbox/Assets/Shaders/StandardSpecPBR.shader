Shader "Holistic/StandardSpecPBR"
{
    Properties 
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _SpecColor ("Specular Color", Color) = (1, 1, 1, 1)
        _MetallicTex ("Metallic (R)", 2D) = "white" {}
    }
    
    SubShader 
    {
        CGPROGRAM
        #pragma surface surf StandardSpecular
        
        sampler2D _MetallicTex;
        half _Metallic;
        fixed4 _Color;
        
        struct Input
        {
            float2 uv_MetallicTex;
        };
        
        void surf(Input IN, inout SurfaceOutputStandardSpecular o)
        {
            o.Specular = _SpecColor.rgb;
            o.Smoothness = 0.9 - tex2D(_MetallicTex, IN.uv_MetallicTex).r;
            o.Albedo = _Color.rgb;
        }
            
        ENDCG
    }
    
     Fallback "Diffuse"
}