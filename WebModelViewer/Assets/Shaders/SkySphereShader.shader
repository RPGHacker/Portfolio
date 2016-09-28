Shader "Custom/Skysphere Shader"
{
	Properties
	{
		_SkysphereTexture ("Skysphere Texture", 2D) = "white" {}
		_EmissiveIntensity("_EmissiveIntensity", Range(0,10)) = 1.0
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		Cull Off
		Lighting Off
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _SkysphereTexture;
		float _EmissiveIntensity;

		struct Input
		{
			float2 uv_SkysphereTexture;
			float3 viewDir;
		};

		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			const float PI = 3.14159265359;

			float3 currentViewDir = IN.viewDir;

			float r = length(currentViewDir);
			float lon = atan2(currentViewDir.x, currentViewDir.z);
			float lat = acos(currentViewDir.y / r);
			
			const float2 rads = float2(1.0 / (PI * 2.0), 1.0 / PI);
			float2 sphereCoords = float2(lon, lat) * rads;

			fixed4 c = tex2D(_SkysphereTexture, sphereCoords);

			o.Albedo = c.rgb;
			o.Emission = c * _EmissiveIntensity;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
