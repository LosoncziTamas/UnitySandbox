Shader "Holistic/Stripes"
{
    Properties 
    {
        _diffuseTex ("Diffuse Texture", 2D) = "white" {}
        _stripeSize ("Stripe Size", Range(0, 1)) = 1
    }
    
    SubShader
    {
        CGPROGRAM
            #pragma surface surf Lambert
            
            float4 _rimColor;
            float _rimPower;
            float _stripeSize;
            sampler2D _diffuseTex;
            
            struct Input
            {
                float3 viewDir;
                float3 worldPos;
                float2 uv_diffuseTex;
            };
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                float rim = 1 - saturate(dot(IN.viewDir, o.Normal));
                float3 stripeColor = (0, 0, 0);
                if (frac(IN.worldPos.y * 0.5 * (1 - _stripeSize)) > 0.4)
                {
                    stripeColor.g = rim;
                }
                else
                {
                    stripeColor.r = rim;
                }
                
                o.Emission = stripeColor;
                o.Albedo = tex2D(_diffuseTex, IN.uv_diffuseTex).rgb;
            }
            
        ENDCG
    }
    
    Fallback "Diffuse"
}