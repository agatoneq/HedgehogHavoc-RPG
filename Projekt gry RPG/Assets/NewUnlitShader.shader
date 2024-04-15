Shader "Shader" {
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
            };


            struct v2f {
                float4 pos : SV_POSITION;
                float3 cameraDifference : TEXCOORD0; 
            };


            v2f vert (appdata v) {
                v2f o;

                float movement = sin(_Time.y * 2.0) * 0.5; 
                float4 modifiedVertex = v.vertex;
                modifiedVertex.y += movement;


                o.pos = UnityObjectToClipPos(modifiedVertex);



                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

                o.cameraDifference = _WorldSpaceCameraPos.xyz - worldPos; 
                return o;
            }


            float4 frag (v2f i) : SV_Target {

                float3 color = normalize(abs(i.cameraDifference));
                return float4(color, 1.0);
            }
            ENDCG
        }
    }
}