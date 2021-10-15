Shader "Mobile/Particles/ColorAdd" {
	Properties {
		_MainTex ("Particle Texture", 2D) = "white" {}
		_ColorCorrectTex ("ColorCorrect Texture", 2D) = "white"{}
		_BlendFactor("Blend Factor", Range(0,1.0)) = 0.5
		_UVRevert("UVRevert", float) = 0
	}

	Category {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Blend SrcAlpha One
		Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
	
		SubShader {
			Pass {

				CGPROGRAM
				#pragma exclude_renderers xbox360
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"
			
				float _UVRevert;
			
				struct v2f
				{
					float4 vertex : POSITION;
					float2 texcoord : TEXCOORD0;
					float4 vertexColor : Color;
				};
			
				v2f vert (appdata_full v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
				
					if(_UVRevert < 0.1)
					{
						o.texcoord.xy = v.texcoord.xy;
					}
					else
					{
						o.texcoord.yx = v.texcoord.xy;
					}
					o.vertexColor = v.color;
				
					return o;
				}
			
				sampler2D _MainTex;			
				float4 _MainTex_ST;
			
				sampler2D _ColorCorrectTex;
				float4 _ColorCorrectTex_ST;
				float _BlendFactor;			
			
				half4 frag (v2f IN) : COLOR
				{
					half4 finalColor = tex2D(_MainTex, IN.texcoord)*IN.vertexColor;
				
					float sum = (finalColor.r + finalColor.g + finalColor.b)/3.0 ;
					_ColorCorrectTex_ST.x = sum;
					fixed4 ColorCorrect = tex2D(_ColorCorrectTex, _ColorCorrectTex_ST.xy + _ColorCorrectTex_ST.zw);				
				
					finalColor.rgb = finalColor.rgb*(1.0 - _BlendFactor) + ColorCorrect.rgb*_BlendFactor;
					finalColor.rgb = finalColor.rgb*IN.vertexColor.rgb;
				
					return finalColor;
				}
				ENDCG									
			}
		}
	}
}