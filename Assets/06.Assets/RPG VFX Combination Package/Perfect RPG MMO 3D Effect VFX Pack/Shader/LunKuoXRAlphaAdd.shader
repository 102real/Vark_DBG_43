//====================appstools.net=======================//

Shader "Custom/Add" {
    Properties {
        _MainTex_Color ("_MainTex_Color", Color) = (1,1,1,1)
        _Nei_Color ("_Nei_Color", Color) = (0.5,0.5,0.5,1)
        _Nei_Color_QiangDu ("_Nei_Color_QiangDu", Range(0, 1)) = 0.5
        _LunKuo_QuanZhong ("_LunKuo_QuanZhong", Range(0, 5)) = 2.5
        _Alpha_QuanZhong ("_Alpha_QuanZhong", Range(0, 8)) = 4
        _All_QuanZhong ("_All_QuanZhong", Range(0, 10)) = 1
        _HunHeTex ("_HunHeTex", 2D) = "white" {}
        _XiaoRong ("XiaoRong", Range(1, 0)) = 1
        [MaterialToggle] _XRSwap ("_XRSwap", Float ) = 0.01
        _Alpha ("Alpha", Range(1, 0)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _MainTex_Color;
            uniform float _XiaoRong;
            uniform float _Alpha;
            uniform fixed _XRSwap;
            uniform sampler2D _HunHeTex; uniform float4 _HunHeTex_ST;
            uniform float4 _Nei_Color;
            uniform float _Nei_Color_QiangDu;
            uniform float _LunKuo_QuanZhong;
            uniform float _Alpha_QuanZhong;
            uniform float _All_QuanZhong;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_6030 = 0;//max(0,dot(node_9887,pow(1.0-max(0,dot(normalDirection, viewDirection)),node_9887)));
                float3 emissive = (((_All_QuanZhong*pow(node_6030,_LunKuo_QuanZhong)*_MainTex_Color.rgb)+(_Nei_Color.rgb*2.0*_Nei_Color_QiangDu))*i.vertexColor.rgb);
                float3 finalColor = emissive;
                float4 _HunHeTex_var = tex2D(_HunHeTex,TRANSFORM_TEX(i.uv0, _HunHeTex));
                float node_4991 = clamp(_HunHeTex_var.r,0.01,1);
                fixed4 finalRGBA = fixed4(finalColor,(i.vertexColor.a*(step(lerp( node_4991, (1.0 - node_4991), _XRSwap ),_XiaoRong)*_Alpha*(pow(node_6030,_Alpha_QuanZhong)*_All_QuanZhong))));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
