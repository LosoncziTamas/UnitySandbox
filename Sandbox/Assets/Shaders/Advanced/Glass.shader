Shader "Holistic/Glass"
{
     Properties
    {
        _MainTexture ("Main Texture", 2D) = "white" {}
        _ScaleUV ("Scale UV", Range(1, 20)) = 1
    }
    
    Subshader
    {
        Tags {"Queue" = "Transparent"}
    
        GrabPass {}
        
        Pass
        {
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                
                #include "UnityCG.cginc"
                
                struct appdata
                {
                    float4 uv : TEXCOORD0;
                    float4 vertex : POSITION;
                };
    
                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 uvgrab: TEXCOORD1;
                    float4 uvbump: TEXCOORD2;
                    float4 vertex : SV_POSITION;
                };
                
                sampler2D _MainTexture;
                sampler2D _GrabTexture;
                float4 _GrabTexture_TexelSize;
                float _ScaleUV;
                
                // The values for this are provided in the inspector by the Tiling/Offset.
                float4 _MainTexture_ST;
                
                v2f vert(appdata v)
                {
                    v2f o;
                    // Transforms a point from object space to the camera’s clip space in homogeneous coordinates. 
                    // This is the equivalent of mul(UNITY_MATRIX_MVP, float4(pos, 1.0))
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    // Math stuff to transform the 
                    o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y) + o.vertex.w) * 0.5f;
                    o.uvgrab.zw = o.vertex.zw;
                    // Transforms 2D UV by scale/bias property equivalent to v.uv * _MainTexture_ST.xy + _MainTexture_ST.zw;
                    o.uv = TRANSFORM_TEX(v.uv, _MainTexture);
                    return o;
                }
                
                fixed4 frag(v2f i) : SV_Target
                {
                    float4 projectedTexCoord = UNITY_PROJ_COORD(i.uvgrab);
                    // Performs a texture lookup in sampler _GrabTexture using coordinates projectedTexCoord. 
                    // The coordinates used in the lookup are first projected, that is, divided by the last component of the coordinate vector and then used in the lookup.
                    fixed4 color = tex2Dproj(_GrabTexture, projectedTexCoord);
                    return color;
                }
            ENDCG
        }
    }
}
