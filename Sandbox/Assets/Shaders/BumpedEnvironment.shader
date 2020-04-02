Shader "Holistic/BumpedEnvironment" {
	
    Properties 
    {
        _diffTex ("Diffuse Texture", 2D) = "white" {}
        _bumpTex ("Bump Texture", 2D) = "white" {}
        _brightness ("Brightness", Range(0, 10)) = 1
        _envMap ("Environment Map", CUBE) = "" {}
    }
    SubShader 
    {

      CGPROGRAM
        #pragma surface surf Lambert
        
        half _brightness;
        sampler2D _diffTex;
        sampler2D _bumpTex;
        samplerCUBE _envMap;

        struct Input 
        {
            float2 uv_diffTex;
            float2 uv_bumpTex;
            float3 worldRefl; INTERNAL_DATA
        };
        
        void surf (Input IN, inout SurfaceOutput o) 
        {
            o.Albedo = tex2D(_diffTex, IN.uv_diffTex).rgb;
            o.Normal = UnpackNormal(tex2D(_bumpTex, IN.uv_bumpTex)) * _brightness;
            o.Emission = texCUBE(_envMap, WorldReflectionVector(IN, o.Normal)).rgb;
        }
      
      ENDCG
    }
    	
	FallBack "Diffuse"
}