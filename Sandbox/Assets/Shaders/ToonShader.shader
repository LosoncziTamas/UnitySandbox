Shader "Holistic/ToonShader"
{

    Properties
    {
        _RampTexture ("Ramp Texture", 2D) = "white" {}
        _Color ("Color", Color) = (0, 0, 0, 0)
    }
    
    SubShader
    {
        CGPROGRAM
            #pragma surface surf Lambert
            
            sampler2D _RampTexture;
            float4 _Color;
                        
            struct Input
            {
                float2 uv_RampTexture;
                float3 viewDir;
            };
            
            void surf(Input IN, inout SurfaceOutput o)
            {
                float diffuse = dot(o.Normal, IN.viewDir);
                // UV coordinates for the ramp image
                float2 rampUV = diffuse * 0.5 + 0.5f;                
                o.Albedo = tex2D(_RampTexture, rampUV).rgb;
            }
            
            float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten)
            {
                float diffuse = dot(s.Normal, lightDir);
                // UV coordinates for the ramp image
                float2 rampUV = diffuse * 0.5 + 0.5f;
                float3 ramp = tex2D(_RampTexture, rampUV).rgb;
                
                float4 result;
                result.rgb = s.Albedo * _LightColor0.rgb * ramp;
                result.a = s.Alpha;
                return result;
            } 
        ENDCG
    }
    
    Fallback "Diffuse"

}