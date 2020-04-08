Shader "Holistic/Hologram"
{
    Properties
    {
        _rimColor ("Rim Light", Color) = (0, 0.5, 0.5, 0)
        _fadeLevel ("Fade level", Range(0, 5)) = 1
    }
    
    SubShader
    {
    
        Pass
        {
            ZWrite On
            ColorMask 0
        }
    
        CGPROGRAM
            #pragma surface surf Lambert alpha:fade
            
            float4 _rimColor;
            float _fadeLevel;
            
            struct Input 
            {
                float3 viewDir;
            };
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                float dotResult = saturate(dot(IN.viewDir, o.Normal));
                float rim = pow((1 - dotResult), _fadeLevel);
                o.Emission = rim * _rimColor.rgb;
                o.Alpha = rim;
            }
            
             
        ENDCG
    }
    Fallback "Diffuse"
}