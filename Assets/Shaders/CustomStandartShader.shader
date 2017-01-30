Shader "Custom/StandartShader"
{
    Properties
    {    	 
        _Albedo ("Albedo (RGB), Alpha (A)", 2D) = "white" {}
        [NoScaleOffset]
        _Metallic ("Metallic (R), Occlusion (G), Emission (B), Smoothness (A)", 2D) = "black" {}
        _Normal ("Normal (RGB)", 2D) = "bump" {}
        _Occlusion ("Occlusion Map", 2D) = "white" {}
         _EmissionColor("Color", Color) = (0,0,0)
        _EmissionMap("Emission", 2D) = "white" {}
    }
 
    SubShader
    {
        Tags
        {            
            "Queue" = "Geometry-1"
			"RenderType" = "Opaque"
			"XRay" = "ColoredOutline"

        }
     
        CGINCLUDE
        #define _GLOSSYENV 1
        ENDCG
     
        CGPROGRAM
        #pragma target 3.0
        #include "UnityPBSLighting.cginc"
        #pragma surface surf Standard
        #pragma exclude_renderers gles
 
        struct Input
        {
            float2 uv_Albedo;
        };
 
        sampler2D _Albedo;
        sampler2D _Normal;
        sampler2D _Metallic;
        sampler2D _Occlusion;
        sampler2D _EmissionMap;
        fixed4 _EmissionColor;
 
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 albedo = tex2D(_Albedo, IN.uv_Albedo);
            fixed4 metallic = tex2D(_Metallic, IN.uv_Albedo);
//            fixed4 occlusion = tex2D(_EmissionMap, IN.);
            fixed3 normal = UnpackScaleNormal(tex2D(_Normal, IN.uv_Albedo), 1);
     
            o.Albedo = albedo.rgb;
            o.Alpha = albedo.a;
            o.Normal = normal;
            o.Smoothness = metallic.a;
            o.Occlusion = metallic.g;
//            o.Emission = ;
            o.Metallic = metallic.r;
        }
        ENDCG
    }
 
    FallBack "Diffuse"
}