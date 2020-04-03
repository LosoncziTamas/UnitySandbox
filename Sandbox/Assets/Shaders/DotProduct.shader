Shader "Holistic/DotProduct" 
{
    Properties 
    {
     
    }
    SubShader {

      CGPROGRAM
        #pragma surface surf Lambert
        
        struct Input {
            float3 viewDir;
        };
        
        void surf (Input IN, inout SurfaceOutput o) {
            float dotResult =  dot(IN.viewDir, o.Normal);
            o.Albedo = float3(0, 1 - dotResult, 0);
        }
      
      ENDCG
    }
    Fallback "Diffuse"
}
