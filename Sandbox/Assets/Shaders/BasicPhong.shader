Shader "Holistic/BasicPhong"
{
    Properties 
    {
        _Color ("Color", Color) = (0, 0, 0, 0)
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf BasicBlinn
        
        float4 _Color;
        half _Spec;
        fixed _Gloss;
        
        half4 LightingBasicBlinn(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
        {
            half3 halfWay = normalize(viewDir + lightDir);
            
            // diffuse color, the closer the normal and light direction are the stronger the point will be.
            half diffuse = max(0, dot(s.Normal, lightDir));
            
            // specular strength aka. fall-off
            float fallOff = max(0, dot(s.Normal, halfWay));
            // 48 is what Unity uses for the specular component
            float spec = pow(fallOff, 48.0);
            
            half4 result;            
            result.rgb = (s.Albedo * _LightColor0.rgb * diffuse + _LightColor0.rgb * spec) * atten * _SinTime;

            result.a = s.Alpha;
            return result;
        }        
        
        struct Input
        {
            float2 uv_Maintex;
        };
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
        }
        
        ENDCG
    }
    
    Fallback "Diffuse"
    

}