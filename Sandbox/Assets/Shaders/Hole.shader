Shader "Holistic/Hole"
{
    SubShader
    {
        ColorMask 0
        ZWrite off
        
        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }
        
        Pass {}

    }
    
    Fallback "Diffuse"
}