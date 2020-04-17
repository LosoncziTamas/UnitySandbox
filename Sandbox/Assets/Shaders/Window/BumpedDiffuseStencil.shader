Shader "Holistic/BumpedDiffuseStencil"
{

    Properties
    {
        _Color ("Albedo Color", Color) = (0, 0, 0, 0)
        
        _SRef ("Stencil Value", Float) = 1
        [Enum(UnityEngine.Rendering.CompareFunction)] _SComp ("Stencil Comp", Float) = 8
        [Enum(UnityEngine.Rendering.StencilOp)] _SOp ("Stencil Op", Float) = 2
    }
    
    Subshader
    {
        Tags {"Queue" = "Geometry"}
    
        Stencil
        {
            Ref [_SRef]
            Comp [_SComp]
            Pass [_SOp]
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