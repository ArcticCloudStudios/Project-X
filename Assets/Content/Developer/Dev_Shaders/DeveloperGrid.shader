Shader "Custom/DeveloperGrid" {
	Properties {
		_CellColor ("Cell Color", Color) = (0,0,0,1)
		[HDR] _LineColor ("Line Color", Color) = (1,1,1,1)
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_UVScale ("UV Scale", Vector) = (1, 1, 1, 1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		struct Input {
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _CellColor;
		fixed4 _LineColor;
		fixed4 _UVScale;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			
			float3 coord = (IN.worldPos - mul(unity_ObjectToWorld, float4(0, 0, 0, 1)).xyz) * _UVScale.xyz;
			float3 grid = abs(frac(coord - 0.5) - 0.5) / fwidth(coord);
			float l = min(min(grid.x, grid.y), grid.z);
			
			float4 c = lerp(_LineColor, _CellColor, min(l, 1.0));

			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Emission = lerp(_LineColor, float4(0, 0, 0, 1), min(l, 1.0));
		}
		ENDCG
	}
	FallBack "Diffuse"
}
