Shader "Holistic/VFChallenge1"
{
    Properties
    {
        _Texture ("Texture", 2D) = "white" {}
    }
    
    Subshader
    {
        Pass 
        {
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                
                #include "UnityCG.cginc"
                
                struct appdata
                {
                    float4 uv: TEXCOORD0;
                    float4 vertex: POSITION;
                };
                
                struct v2f
                {
                    float2 uv: TEXCOORD0;
                    float4 vertex: SV_POSITION;
                    float4 color: COLOR;
                };
                
                sampler2D _Texture;
                float4 _Texture_ST;
                
                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _Texture);
                    o.color.r = o.uv.x;
                    return o;
                }
                
                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 color = tex2D(_Texture, i.uv) * i.color;
                    return color;
                }
              
                
            ENDCG
        }
    }
    
}