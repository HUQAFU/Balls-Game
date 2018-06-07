Shader "Custom/ColorHightlight" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert 

		struct Input {
			float4 screenPos;
		};


		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput  o) {
			//Fill albedo and emission with color (i'm not using texture)
			fixed4 c = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
			o.Albedo = c.rgb + IN.screenPos.y;
			//highlight Emission with screenpos by Y
			o.Emission = c.rgb ;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
