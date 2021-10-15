Shader "AppsTools/FastShader/Effect/Fast_Color_Alpha_Blend" {
	Properties{
		_MainTex("MainTex", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
	}
		Category{
			Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Off Lighting Off ZWrite Off

			SubShader {
				Pass {

					CGPROGRAM
					#pragma vertex vert
					#pragma fragment frag
					#pragma multi_compile_fog

					#include "UnityCG.cginc"
					fixed4 _Color;
					sampler2D _MainTex;

					struct appdata_t {
						float4 vertex : POSITION;
						fixed4 color : COLOR;
						float2 texcoord : TEXCOORD0;
					};

					struct v2f {
						float4 vertex : SV_POSITION;
						fixed4 color : COLOR;
						float2 texcoord : TEXCOORD0;
						UNITY_FOG_COORDS(1)
					};

					float4 _MainTex_ST;

					v2f vert(appdata_t v)
					{
						v2f o;
						o.vertex = UnityObjectToClipPos(v.vertex);
						o.color = v.color;
						o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
						UNITY_TRANSFER_FOG(o,o.vertex);
						return o;
					}

					fixed4 frag(v2f i) : SV_Target
					{
						fixed4 col = i.color * tex2D(_MainTex, i.texcoord) * _Color;
						UNITY_APPLY_FOG_COLOR(i.fogCoord, col, fixed4(0,0,0,0)); 
						return col;
					}
					ENDCG
				}
			}
	}
}
