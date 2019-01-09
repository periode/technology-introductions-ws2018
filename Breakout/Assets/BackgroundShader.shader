Shader "Unlit/BackgroundShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,0.2)
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

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

            float random( float2 p )
            {
                float2 K1;
                K1.x = 23.14069263277926+_Time*0.01; // e^pi (Gelfond's constant)
                K1.y = 2.665144142690225; // 2^sqrt(2) (Gelfondâ€“Schneider constant)

                return frac( cos( dot(p,K1) ) * 12345.6789 );
            }
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				//fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
                // col = col * (random(i.uv)-0.85);
                //col.r = col.g = col.b. = 0.;

                float4 col = float4(0., 0.2, 0., 0.);
                col.r += cos(_Time*4.0)*i.uv.x;
                col.g += sin(_Time*2.0)*i.uv.y;
                col.b += i.uv.x + i.uv.y;

                if(distance(float4(i.uv.x, i.uv.y, 0., 0.), float4(0.5, 0.5, 0., 0.)) > 0.24){
                    col.r = col.g = col.b = 0.;
                }

				return col;
			}
			ENDCG
		}
	}
}
