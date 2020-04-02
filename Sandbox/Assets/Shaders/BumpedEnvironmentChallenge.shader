Shader "Holistic/BumpedEnvironmentChallenge" {
	
    Properties 
    {
        _bumpTex ("Bump Texture", 2D) = "white" {}
        _envMap ("Environment Map", CUBE) = "" {}
    }
    SubShader 
    {

      CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _bumpTex;
        samplerCUBE _envMap;

        struct Input 
        {
            float2 uv_bumpTex;
            float3 worldRefl; INTERNAL_DATA
        };
        
        void surf (Input IN, inout SurfaceOutput o) 
        {
            o.Normal = UnpackNormal(tex2D(_bumpTex, IN.uv_bumpTex)) * 0.3f;
            o.Albedo = texCUBE(_envMap, WorldReflectionVector(IN, o.Normal)).rgb;
        }
      
      ENDCG
    }
    	
	FallBack "Diffuse"
}