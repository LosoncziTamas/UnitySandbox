Shader "Holistic/Transparent"
{

    Properties
    {
        _Texture ("Texture", 2D) = "white" {}    
    }
    
    SubShader
    {
        CGPROGRAM
            #pragma surface surf Lambert alpha:fade
            
            sampler2D _Texture;
            
            struct Input
            {
                float2 uv_Texture; 
            };
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                half4 color = tex2D(_Texture, IN.uv_Texture);
                o.Albedo = color.rgb;
                o.Alpha = color.a;
            }
            
        ENDCG
    }
    
    Fallback "Diffuse"
}