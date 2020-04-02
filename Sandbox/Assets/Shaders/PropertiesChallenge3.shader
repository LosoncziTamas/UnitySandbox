Shader "Holistic/PropChallenge3" 
{
/*
    Create a shader that has only one property which is a texture. This texture should colour the albedo. 
    To this texture, before applying it to the albedo apply the colour green.
*/
    Properties {
        _myTex ("Example Texture", 2D) = "white" {}
    }
    SubShader {

      CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _myTex;

        struct Input {
            float2 uv_myTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o) {
            float4 green = float4(0, 1, 0, 1);
            fixed3 texColor = tex2D(_myTex, IN.uv_myTex).rgb;
            o.Albedo.g = 1.0f;
            o.Albedo += texColor;
        }
      
      ENDCG
    }
    Fallback "Diffuse"
}