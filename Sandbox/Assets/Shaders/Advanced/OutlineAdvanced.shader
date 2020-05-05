Shader "Holistic/OutlineAdvanced"
{

    Properties
    {
        _Amount("Amount", Range(0, 10)) = 0
        _MainTex("Main Texture", 2D) = "white" {}
        _OutlineCol("Outline Color", Color) = (0, 0, 0, 0)
    }
    
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        
        struct Input
        {
            float2 uv_MainTex;
        };
        
        sampler2D _MainTex;
        float4 _OutlineCol;
        float _Amount;
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex);
        }
        ENDCG
        
        Pass
        {
            Cull Front
        
            CGPROGRAM
            #pragma vertex vert 
            #pragma fragment frag
            
            #include "UnityCG.cginc" 
            
            float4 _OutlineCol;
            float _Amount;
            
            struct app_data
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            
            struct v2f
            {
                float4 pos: SV_POSITION;
                fixed4 color: COLOR;
            };
            
            v2f vert(app_data v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                // rotating normals from object into eye space.
                float3 normal = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
                float offset = TransformViewToProjection(normal.xy);
                o.pos.xy += offset * o.pos.z * _Amount;
                o.color.rgb = v.normal;
                return o;
            }
            
            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color = i.color;
                return color;
            }
            
            ENDCG
        }

    }
    
    Fallback "Diffuse"

}