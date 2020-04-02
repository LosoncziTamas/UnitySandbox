Shader "Holistic/BumpDiffuse"
{
    Properties 
    {
        _diffuseTex ("Diffuse Texture", 2D) = "white"{}
        _normalMap ("Normal Map", 2D) = "bump"{}
        _bumpAmount ("Bump Amount", Range(0, 10)) = 1
        _bumpScale ("Bump Scale", Range(0.5, 2)) = 1
    }
    
   Subshader 
   {
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _diffuseTex;
        sampler2D _normalMap;
        half _bumpAmount;
        half _bumpScale;
        
        struct Input 
        {
            float2 uv_diffuseTex;
            float2 uv_normalMap;
        };
        
        void surf(Input IN, inout SurfaceOutput o) 
        {
            o.Albedo = tex2D(_diffuseTex, IN.uv_diffuseTex * _bumpScale).rgb;
            float3 normal = UnpackNormal(tex2D(_normalMap, IN.uv_normalMap * _bumpScale));
            normal *= float3(_bumpAmount, _bumpAmount, 1);
            o.Normal = normal;
        }

        ENDCG
   }
   
   Fallback "Diffuse"
}