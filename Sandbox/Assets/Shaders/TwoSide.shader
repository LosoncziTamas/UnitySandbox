Shader "Holistic/TwoSide"
{
    Properties 
    {
        _Texture ("Texture", 2D) = "white" {}
    }
    
    SubShader 
    {
        Tags {"Queue" = "Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off

        Pass
        {
            SetTexture [_Texture] {combine texture}
        }        
        
        
    }
    
    Fallback "Diffuse"
}