Shader "Holistic/Rim"
{
    Properties
    {
        _rimColor ("Rim Light", Color) = (0, 0.5, 0.5, 0)
        _fadeLevel ("Fade level", Range(0, 5)) = 1
    }
    
    SubShader
    {
        CGPROGRAM
            #pragma surface surf Lambert
            
            float4 _rimColor;
            float _fadeLevel;
            
            struct Input 
            {
                float3 viewDir;
            };
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                float dotResult = saturate(dot(IN.viewDir, o.Normal));
                o.Emission = pow((1 - dotResult), _fadeLevel) * _rimColor.rgb;
            }
            
             
        ENDCG
    }
    Fallback "Diffuse"
}