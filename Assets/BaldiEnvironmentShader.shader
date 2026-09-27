// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Baldi/BaldiEnvironmentShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			const float EPSILON = 2.4414e-4;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				//UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _MainTex_TexelSize;

			fixed4 color;

			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				float3 world = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.uv = world.xz;
				o.uv *= .1;
				UNITY_TRANSFER_FOG(o, o.vertex);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				float2 uv = i.uv;
				uv -= float2(-.5, .5);

				// weird sampling math
				if (uv.x > 0.) {
					if (uv.x > 1.) {
						uv.x = frac(uv.x);
					}
				}

				uv *= _MainTex_ST.xy;
				uv += _MainTex_ST.zw;

				fixed4 col = 0.;
				col = tex2D(_MainTex, uv);
				return col;
			}
			ENDCG
		}
	}
}
