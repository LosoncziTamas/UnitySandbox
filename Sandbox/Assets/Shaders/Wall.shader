Shader "Holistic/Wall"
{
    Properties
    {
        _Color ("Albedo", Color) = (0, 0, 0, 0)
    }
    
    SubShader
    {
        Stencil
        {
            Ref 1
            Comp notequal
            Pass keep
        }
    
        CGPROGRAM
        #pragma surface surf Lambert
        
        float4 _Color;
        
        struct Input
        {
            float2 uv;  
        };
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color;
        }
        
        ENDCG
    }
    
    Fallback "Diffuse"
}