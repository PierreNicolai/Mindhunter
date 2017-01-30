Shader "XRay Shaders/Diffuse-Stencil-Write"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo", 2D) = "white" {}
		[Gamma] _Metallic("Metallic", Range(0.0, 1.0)) = 0.0
		_MetallicGlossMap("Metallic", 2D) = "white" {}
		_BumpScale("Scale", Float) = 1.0
		_BumpMap("Normal Map", 2D) = "bump" {}
		_EdgeColor("XRay Edge Color", Color) = (0,0,0,0)	
		_Glossiness("Smoothness", Range(0.0, 1.0)) = 0.5
		_EmissionColor("Emission Color", Color) = (0,0,0)
        _EmissionMap("Emission", 2D) = "white" {}
         _Occlusion ("Occlusion Map", 2D) = "white" {}
        [NoScaleOffset] _HeightMap ("Heights", 2D) = "gray" {}
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }


		Stencil
		{
			Ref 1
			Comp Always
			Pass Replace
		}

		CGPROGRAM
		#pragma surface surf Standard	

		 #include "UnityPBSLighting.cginc"

		fixed4 _Color;
		float _Metallic;
		float _Glossiness;

		sampler2D _BumpMap;
		sampler2D _MainTex;
		sampler2D _MetallicGlossMap;
		sampler2D _EmissionMap;
		sampler2D _HeightMap;
		sampler2D _Occlusion;
        fixed4 _EmissionColor;
       
		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
//			c *= tex2D(_HeightMap, IN.uv_MainTex);
			fixed4 metal = tex2D(_MetallicGlossMap, IN.uv_MainTex);
			fixed4 emi = tex2D(_EmissionMap, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Metallic = metal * _Metallic;
			o.Smoothness = metal.a * _Glossiness;
			o.Emission = emi * _EmissionColor;
			o.Normal = UnpackScaleNormal(tex2D(_BumpMap, IN.uv_BumpMap), 1);
			o.Occlusion =  tex2D(_Occlusion, IN.uv_MainTex);;
		}
		ENDCG
	}
	
	Fallback "Legacy Shaders/VertexLit"
}
