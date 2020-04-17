Shader "Holistic/WindowStencil"
{
    Properties
    {
        _SRef ("Stencil Value", Float) = 1
        [Enum(UnityEngine.Rendering.CompareFunction)] _SComp ("Stencil Comp", Float) = 8
        [Enum(UnityEngine.Rendering.StencilOp)] _SOp ("Stencil Op", Float) = 2
    }
    
    SubShader
    {
        ZWrite off
        ColorMask 0
        
        Tags {"Queue" = "Geometry-1"}
        
        Stencil
        {
            Ref [_SRef]
            Comp [_SComp]
            Pass [_SOp]
        }
        
        Pass {}
    }
    
    Fallback "Diffuse"
}