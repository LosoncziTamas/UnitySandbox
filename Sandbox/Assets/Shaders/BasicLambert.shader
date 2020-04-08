Shader "Holistic/BasicLambert"
{
    Properties 
    {
        _Color ("Color", Color) = (0, 0, 0, 0)
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        
        float4 _Color;
        
        struct Input
        {
            float2 uv_Maintex;
        };
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
        }
        
        ENDCG
    }
    
    Fallback "Diffuse"
    

}