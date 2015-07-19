Shader "Custom/LaserBolt" {
	Properties {
		_ColorTint("Color Tint", Color) = (1, 1, 1, 0)
		_RimColor("RimColor", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(1.0, 6.0)) = 3.0
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
       
        CGPROGRAM
        #pragma surface surf Lambert alpha
 
		float4 _ColorTint;
		float4 _RimColor;
		float _RimPower;
 
        struct Input {
			float4 color : Color;
            float3 viewDir;
        };
 
        void surf (Input IN, inout SurfaceOutput o) {
            IN.color = _ColorTint;
			o.Albedo = IN.color;

			half rim = saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
			o.Alpha = _RimColor.a * pow(rim, _RimPower);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
