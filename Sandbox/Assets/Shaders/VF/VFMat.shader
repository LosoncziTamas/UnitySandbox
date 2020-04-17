Shader "Holistic/VFMat"
{
    Properties
    {
        _MainTexture ("Main Texture", 2D) = "white" {}
        _ScaleX ("Scale X", Range(0, 10)) = 1
        _ScaleY ("Scale Y", Range(0, 10)) = 1
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
                    float2 uv : TEXCOORD0;
                    float4 vertex : POSITION;
                };
    
                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };
                
                sampler2D _MainTexture;
                sampler2D _GrabTexture;
                float _ScaleX;
                float _ScaleY;
                float4 _MainTexture_ST;
                
                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTexture);
                    o.uv.x = sin(o.uv.x * _ScaleX);
                    o.uv.y = sin(o.uv.y * _ScaleY);
                    return o;
                }
                
                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 color = tex2D(_GrabTexture, i.uv);
                    return color;
                }
            ENDCG
        }
    }
}