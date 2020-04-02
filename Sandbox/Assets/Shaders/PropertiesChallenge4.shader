Shader "Holistic/PropChallenge4" 
{
/*
    1. Write a shader that has two properties; one for a diffuse texture and one for a emissive texture. 
    
    2. Use the attached images to test with Zombunny. There is one for diffuse and one for emissive. 
    
    3. Apply the diffuse to the model's albedo and the emissive to the emission. 
    
    What do you notice happens to the visual result when only a diffuse texture is given and no emissive one?
    
    How do you think this is corrected? 
*/
    Properties {
        _diffTex ("Diffuse Texture", 2D) = "white" {}
        _emissiveTex ("Emissive Texture", 2D) = "black" {}
    }
    SubShader {

      CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _diffTex;
        sampler2D _emissiveTex;

        struct Input {
            float2 uv_diffTex;
            float2 uv_emissiveTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = tex2D(_diffTex, IN.uv_diffTex).rgb;
            o.Emission = tex2D(_emissiveTex, IN.uv_emissiveTex).rgb;
        }
      
      ENDCG
    }
    Fallback "Diffuse"
}