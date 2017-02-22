// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:2,dpts:2,wrdp:False,dith:0,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9167,x:32719,y:32712,varname:node_9167,prsc:2|diff-8623-RGB,spec-6358-OUT,gloss-7370-OUT,normal-6227-OUT,emission-2458-OUT,alpha-9897-OUT,refract-8625-OUT;n:type:ShaderForge.SFN_Slider,id:6358,x:32289,y:32440,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_6358,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Slider,id:7370,x:32219,y:32591,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:_node_6358_copy,prsc:2,min:0,cur:0.06943462,max:1;n:type:ShaderForge.SFN_Color,id:8623,x:32463,y:32241,ptovrint:False,ptlb:Base Color,ptin:_BaseColor,varname:node_8623,prsc:2,glob:False,c1:0.4761029,c2:0.7594574,c3:0.875,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7470,x:30404,y:32538,ptovrint:False,ptlb:Waves 1,ptin:_Waves1,varname:node_7470,prsc:2,tex:504bce5a0454eb340bb7b333ca20c070,ntxv:0,isnm:False|UVIN-8415-UVOUT;n:type:ShaderForge.SFN_Panner,id:8415,x:30215,y:32538,varname:node_8415,prsc:2,spu:0.1,spv:0;n:type:ShaderForge.SFN_Panner,id:2158,x:30215,y:32743,varname:node_2158,prsc:2,spu:0.5,spv:0;n:type:ShaderForge.SFN_Tex2d,id:738,x:30404,y:32743,ptovrint:False,ptlb:Waves 2,ptin:_Waves2,varname:_node_7470_copy,prsc:2,tex:504bce5a0454eb340bb7b333ca20c070,ntxv:0,isnm:False|UVIN-2158-UVOUT;n:type:ShaderForge.SFN_Add,id:2695,x:30654,y:32643,varname:node_2695,prsc:2|A-7470-RGB,B-738-RGB;n:type:ShaderForge.SFN_Multiply,id:566,x:30852,y:32722,varname:node_566,prsc:2|A-2695-OUT,B-1829-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1829,x:30593,y:32849,ptovrint:False,ptlb:Multiply Waves 1 & 2,ptin:_MultiplyWaves12,varname:node_1829,prsc:2,glob:False,v1:1.2;n:type:ShaderForge.SFN_Panner,id:2756,x:29677,y:33092,varname:node_2756,prsc:2,spu:0.25,spv:0;n:type:ShaderForge.SFN_Tex2d,id:6131,x:29963,y:33103,ptovrint:False,ptlb:Normal Waves 1,ptin:_NormalWaves1,varname:node_6131,prsc:2,tex:2b953bf7908c0524f915cc3d81bece6b,ntxv:3,isnm:True|UVIN-2756-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6054,x:30231,y:33337,ptovrint:False,ptlb:Bottom Mask,ptin:_BottomMask,varname:node_6054,prsc:2,tex:8d7affd591661104b8cbec4e770c3ee0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6077,x:30759,y:33138,varname:node_6077,prsc:2|A-6054-RGB,B-4039-OUT;n:type:ShaderForge.SFN_Add,id:9017,x:30585,y:33468,varname:node_9017,prsc:2|A-6054-RGB,B-3134-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4039,x:30521,y:33341,ptovrint:False,ptlb:bottom Mask add1,ptin:_bottomMaskadd1,varname:_node_1829_copy,prsc:2,glob:False,v1:0.05;n:type:ShaderForge.SFN_ValueProperty,id:3134,x:30388,y:33502,ptovrint:False,ptlb:Bottm Mask add2,ptin:_BottmMaskadd2,varname:_node_1829_copy_copy,prsc:2,glob:False,v1:0.2;n:type:ShaderForge.SFN_OneMinus,id:8558,x:30811,y:33421,varname:node_8558,prsc:2|IN-9017-OUT;n:type:ShaderForge.SFN_Multiply,id:1868,x:31075,y:32833,varname:node_1868,prsc:2|A-566-OUT,B-6077-OUT;n:type:ShaderForge.SFN_Add,id:1243,x:31282,y:33239,varname:node_1243,prsc:2|A-1868-OUT,B-8558-OUT;n:type:ShaderForge.SFN_Tex2d,id:8290,x:30470,y:33654,ptovrint:False,ptlb:Side Mask,ptin:_SideMask,varname:node_8290,prsc:2,tex:1900c93c89473c641b7941a308d74868,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:6317,x:31029,y:33589,varname:node_6317,prsc:2|IN-6054-RGB;n:type:ShaderForge.SFN_Multiply,id:5793,x:31389,y:33461,varname:node_5793,prsc:2|A-1243-OUT,B-6317-OUT;n:type:ShaderForge.SFN_Panner,id:7927,x:30711,y:33908,varname:node_7927,prsc:2,spu:0.2,spv:0;n:type:ShaderForge.SFN_Multiply,id:7299,x:31160,y:33861,varname:node_7299,prsc:2|A-4943-RGB,B-5651-OUT;n:type:ShaderForge.SFN_Multiply,id:6344,x:31357,y:33783,varname:node_6344,prsc:2|A-8290-RGB,B-7299-OUT;n:type:ShaderForge.SFN_Add,id:6232,x:31598,y:33476,varname:node_6232,prsc:2|A-5793-OUT,B-6344-OUT;n:type:ShaderForge.SFN_Multiply,id:8790,x:31996,y:33185,varname:node_8790,prsc:2|A-2343-OUT,B-6232-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5651,x:31013,y:34069,ptovrint:False,ptlb:Intense Side Wave,ptin:_IntenseSideWave,varname:node_5651,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:4943,x:30903,y:33878,ptovrint:False,ptlb:Side waves,ptin:_Sidewaves,varname:node_4943,prsc:2,tex:504bce5a0454eb340bb7b333ca20c070,ntxv:0,isnm:False|UVIN-7927-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:1776,x:31990,y:33652,varname:node_1776,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5426-OUT;n:type:ShaderForge.SFN_ComponentMask,id:93,x:31507,y:33030,varname:node_93,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2343-OUT;n:type:ShaderForge.SFN_Multiply,id:1962,x:31978,y:33016,varname:node_1962,prsc:2|A-93-OUT,B-1776-OUT;n:type:ShaderForge.SFN_Multiply,id:9840,x:31334,y:32564,varname:node_9840,prsc:2|A-566-OUT,B-4763-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4763,x:31102,y:32736,ptovrint:False,ptlb:Multiply Emissive Wave,ptin:_MultiplyEmissiveWave,varname:node_4763,prsc:2,glob:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:9036,x:31602,y:32569,varname:node_9036,prsc:2|A-9978-RGB,B-9840-OUT;n:type:ShaderForge.SFN_Tex2d,id:9978,x:31280,y:32330,ptovrint:False,ptlb:Slim Waves,ptin:_SlimWaves,varname:node_9978,prsc:2,tex:ed9fadfb400f45b46a7e1f185f4e0858,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2458,x:31940,y:32596,varname:node_2458,prsc:2|A-3402-RGB,B-9036-OUT;n:type:ShaderForge.SFN_Color,id:3402,x:31861,y:32355,ptovrint:False,ptlb:Emissive Color,ptin:_EmissiveColor,varname:node_3402,prsc:2,glob:False,c1:0.2279412,c2:0.9680526,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8481,x:31996,y:33377,ptovrint:False,ptlb:Normal Mesh,ptin:_NormalMesh,varname:node_8481,prsc:2,tex:e7fed939f06be5c4193a1c48932da8d0,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Add,id:6227,x:32256,y:33211,varname:node_6227,prsc:2|A-8790-OUT,B-8481-RGB;n:type:ShaderForge.SFN_OneMinus,id:9274,x:31598,y:33692,varname:node_9274,prsc:2|IN-6054-RGB;n:type:ShaderForge.SFN_Panner,id:8344,x:29704,y:32900,varname:node_8344,prsc:2,spu:0.1,spv:0;n:type:ShaderForge.SFN_Tex2d,id:5572,x:29950,y:32915,ptovrint:False,ptlb:Normal Waves 2,ptin:_NormalWaves2,varname:_NormalWaves_copy,prsc:2,tex:2b953bf7908c0524f915cc3d81bece6b,ntxv:3,isnm:True|UVIN-8344-UVOUT;n:type:ShaderForge.SFN_Add,id:7266,x:30151,y:32957,varname:node_7266,prsc:2|A-5572-RGB,B-6131-RGB;n:type:ShaderForge.SFN_Multiply,id:9897,x:32269,y:33631,varname:node_9897,prsc:2|A-1776-OUT,B-9838-OUT;n:type:ShaderForge.SFN_Slider,id:9838,x:32066,y:33854,ptovrint:False,ptlb:Alpha,ptin:_Alpha,varname:node_9838,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:5426,x:31794,y:33626,varname:node_5426,prsc:2|A-6232-OUT,B-9274-OUT;n:type:ShaderForge.SFN_Multiply,id:8625,x:32217,y:32973,varname:node_8625,prsc:2|A-8289-OUT,B-1962-OUT;n:type:ShaderForge.SFN_Slider,id:8289,x:31931,y:32901,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:node_8289,prsc:2,min:0,cur:1,max:2;n:type:ShaderForge.SFN_Multiply,id:2343,x:30495,y:32967,varname:node_2343,prsc:2|A-7266-OUT,B-2275-OUT;n:type:ShaderForge.SFN_Slider,id:2275,x:30170,y:33165,ptovrint:False,ptlb:Normal Intensity,ptin:_NormalIntensity,varname:node_2275,prsc:2,min:0,cur:1,max:1;proporder:6358-7370-8623-6131-7470-738-1829-6054-4039-3134-8290-5651-4943-4763-9978-3402-8481-5572-9838-8289-2275;pass:END;sub:END;*/

Shader "Shader Forge/M_Flotte-01a" {
    Properties {
        _Metallic ("Metallic", Range(0, 1)) = 1
        _Roughness ("Roughness", Range(0, 1)) = 0.06943462
        _BaseColor ("Base Color", Color) = (0.4761029,0.7594574,0.875,1)
        _NormalWaves1 ("Normal Waves 1", 2D) = "bump" {}
        _Waves1 ("Waves 1", 2D) = "white" {}
        _Waves2 ("Waves 2", 2D) = "white" {}
        _MultiplyWaves12 ("Multiply Waves 1 & 2", Float ) = 1.2
        _BottomMask ("Bottom Mask", 2D) = "white" {}
        _bottomMaskadd1 ("bottom Mask add1", Float ) = 0.05
        _BottmMaskadd2 ("Bottm Mask add2", Float ) = 0.2
        _SideMask ("Side Mask", 2D) = "white" {}
        _IntenseSideWave ("Intense Side Wave", Float ) = 0.5
        _Sidewaves ("Side waves", 2D) = "white" {}
        _MultiplyEmissiveWave ("Multiply Emissive Wave", Float ) = 0.1
        _SlimWaves ("Slim Waves", 2D) = "white" {}
        _EmissiveColor ("Emissive Color", Color) = (0.2279412,0.9680526,1,1)
        _NormalMesh ("Normal Mesh", 2D) = "bump" {}
        _NormalWaves2 ("Normal Waves 2", 2D) = "bump" {}
        _Alpha ("Alpha", Range(0, 1)) = 1
        _Refraction ("Refraction", Range(0, 2)) = 1
        _NormalIntensity ("Normal Intensity", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float _Metallic;
            uniform float _Roughness;
            uniform float4 _BaseColor;
            uniform sampler2D _Waves1; uniform float4 _Waves1_ST;
            uniform sampler2D _Waves2; uniform float4 _Waves2_ST;
            uniform float _MultiplyWaves12;
            uniform sampler2D _NormalWaves1; uniform float4 _NormalWaves1_ST;
            uniform sampler2D _BottomMask; uniform float4 _BottomMask_ST;
            uniform float _bottomMaskadd1;
            uniform float _BottmMaskadd2;
            uniform sampler2D _SideMask; uniform float4 _SideMask_ST;
            uniform float _IntenseSideWave;
            uniform sampler2D _Sidewaves; uniform float4 _Sidewaves_ST;
            uniform float _MultiplyEmissiveWave;
            uniform sampler2D _SlimWaves; uniform float4 _SlimWaves_ST;
            uniform float4 _EmissiveColor;
            uniform sampler2D _NormalMesh; uniform float4 _NormalMesh_ST;
            uniform sampler2D _NormalWaves2; uniform float4 _NormalWaves2_ST;
            uniform float _Alpha;
            uniform float _Refraction;
            uniform float _NormalIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 screenPos : TEXCOORD7;
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
            #endif
            #ifdef DYNAMICLIGHTMAP_ON
                o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
            #endif
            o.normalDir = UnityObjectToWorldNormal(v.normal);
            o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
            o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
            o.posWorld = mul(unity_ObjectToWorld, v.vertex);
            float3 lightColor = _LightColor0.rgb;
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            o.screenPos = o.pos;
            return o;
        }
        float4 frag(VertexOutput i) : COLOR {
            #if UNITY_UV_STARTS_AT_TOP
                float grabSign = -_ProjectionParams.x;
            #else
                float grabSign = _ProjectionParams.x;
            #endif
            i.normalDir = normalize(i.normalDir);
            i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
            i.screenPos.y *= _ProjectionParams.x;
            float4 node_2105 = _Time + _TimeEditor;
            float2 node_8344 = (i.uv0+node_2105.g*float2(0.1,0));
            float3 _NormalWaves2_var = UnpackNormal(tex2D(_NormalWaves2,TRANSFORM_TEX(node_8344, _NormalWaves2)));
            float2 node_2756 = (i.uv0+node_2105.g*float2(0.25,0));
            float3 _NormalWaves1_var = UnpackNormal(tex2D(_NormalWaves1,TRANSFORM_TEX(node_2756, _NormalWaves1)));
            float3 node_2343 = ((_NormalWaves2_var.rgb+_NormalWaves1_var.rgb)*_NormalIntensity);
            float2 node_8415 = (i.uv0+node_2105.g*float2(0.1,0));
            float4 _Waves1_var = tex2D(_Waves1,TRANSFORM_TEX(node_8415, _Waves1));
            float2 node_2158 = (i.uv0+node_2105.g*float2(0.5,0));
            float4 _Waves2_var = tex2D(_Waves2,TRANSFORM_TEX(node_2158, _Waves2));
            float3 node_566 = ((_Waves1_var.rgb+_Waves2_var.rgb)*_MultiplyWaves12);
            float4 _BottomMask_var = tex2D(_BottomMask,TRANSFORM_TEX(i.uv0, _BottomMask));
            float4 _SideMask_var = tex2D(_SideMask,TRANSFORM_TEX(i.uv0, _SideMask));
            float2 node_7927 = (i.uv0+node_2105.g*float2(0.2,0));
            float4 _Sidewaves_var = tex2D(_Sidewaves,TRANSFORM_TEX(node_7927, _Sidewaves));
            float3 node_6232 = ((((node_566*(_BottomMask_var.rgb+_bottomMaskadd1))+(1.0 - (_BottomMask_var.rgb+_BottmMaskadd2)))*(1.0 - _BottomMask_var.rgb))+(_SideMask_var.rgb*(_Sidewaves_var.rgb*_IntenseSideWave)));
            float node_1776 = (node_6232*(1.0 - _BottomMask_var.rgb)).r;
            float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction*(node_2343.rg*node_1776));
            float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
            float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 _NormalMesh_var = UnpackNormal(tex2D(_NormalMesh,TRANSFORM_TEX(i.uv0, _NormalMesh)));
            float3 normalLocal = ((node_2343*node_6232)+_NormalMesh_var.rgb);
            float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
            
            float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
            i.normalDir *= nSign;
            normalDirection *= nSign;
            
            float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
            float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = 1;
            float3 attenColor = attenuation * _LightColor0.xyz;
            float Pi = 3.141592654;
            float InvPi = 0.31830988618;
///// Gloss:
            float gloss = 1.0 - _Roughness; // Convert roughness to gloss
            float specPow = exp2( gloss * 10.0+1.0);
/// GI Data:
            UnityLight light;
            #ifdef LIGHTMAP_OFF
                light.color = lightColor;
                light.dir = lightDirection;
                light.ndotl = LambertTerm (normalDirection, light.dir);
            #else
                light.color = half3(0.f, 0.f, 0.f);
                light.ndotl = 0.0f;
                light.dir = half3(0.f, 0.f, 0.f);
            #endif
            UnityGIInput d;
            d.light = light;
            d.worldPos = i.posWorld.xyz;
            d.worldViewDir = viewDirection;
            d.atten = attenuation;
            #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                d.ambient = 0;
                d.lightmapUV = i.ambientOrLightmapUV;
            #else
                d.ambient = i.ambientOrLightmapUV;
            #endif
            d.boxMax[0] = unity_SpecCube0_BoxMax;
            d.boxMin[0] = unity_SpecCube0_BoxMin;
            d.probePosition[0] = unity_SpecCube0_ProbePosition;
            d.probeHDR[0] = unity_SpecCube0_HDR;
            d.boxMax[1] = unity_SpecCube1_BoxMax;
            d.boxMin[1] = unity_SpecCube1_BoxMin;
            d.probePosition[1] = unity_SpecCube1_ProbePosition;
            d.probeHDR[1] = unity_SpecCube1_HDR;
            UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
            lightDirection = gi.light.dir;
            lightColor = gi.light.color;
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float LdotH = max(0.0,dot(lightDirection, halfDirection));
            float3 diffuseColor = _BaseColor.rgb; // Need this for specular when using metallic
            float specularMonochrome;
            float3 specularColor;
            diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
            specularMonochrome = 1-specularMonochrome;
            float NdotV = max(0.0,dot( normalDirection, viewDirection ));
            float NdotH = max(0.0,dot( normalDirection, halfDirection ));
            float VdotH = max(0.0,dot( viewDirection, halfDirection ));
            float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
            float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
            float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
            float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
            half grazingTerm = saturate( gloss + specularMonochrome );
            float3 indirectSpecular = (gi.indirect.specular);
            indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
            float3 specular = (directSpecular + indirectSpecular);
/// Diffuse:
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
            float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
            float3 indirectDiffuse = float3(0,0,0);
            indirectDiffuse += gi.indirect.diffuse;
            float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
// Emissive:
            float4 _SlimWaves_var = tex2D(_SlimWaves,TRANSFORM_TEX(i.uv0, _SlimWaves));
            float3 emissive = (_EmissiveColor.rgb*(_SlimWaves_var.rgb*(node_566*_MultiplyEmissiveWave)));
// Final Color:
            float3 finalColor = diffuse + specular + emissive;
            return fixed4(lerp(sceneColor.rgb, finalColor,(node_1776*_Alpha)),1);
        }
        ENDCG
    }
    Pass {
        Name "FORWARD_DELTA"
        Tags {
            "LightMode"="ForwardAdd"
        }
        Blend One One
        Cull Off
        ZWrite Off
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #define UNITY_PASS_FORWARDADD
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #define _GLOSSYENV 1
        #include "UnityCG.cginc"
        #include "AutoLight.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #pragma multi_compile_fwdadd
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform sampler2D _GrabTexture;
        uniform float4 _TimeEditor;
        uniform float _Metallic;
        uniform float _Roughness;
        uniform float4 _BaseColor;
        uniform sampler2D _Waves1; uniform float4 _Waves1_ST;
        uniform sampler2D _Waves2; uniform float4 _Waves2_ST;
        uniform float _MultiplyWaves12;
        uniform sampler2D _NormalWaves1; uniform float4 _NormalWaves1_ST;
        uniform sampler2D _BottomMask; uniform float4 _BottomMask_ST;
        uniform float _bottomMaskadd1;
        uniform float _BottmMaskadd2;
        uniform sampler2D _SideMask; uniform float4 _SideMask_ST;
        uniform float _IntenseSideWave;
        uniform sampler2D _Sidewaves; uniform float4 _Sidewaves_ST;
        uniform float _MultiplyEmissiveWave;
        uniform sampler2D _SlimWaves; uniform float4 _SlimWaves_ST;
        uniform float4 _EmissiveColor;
        uniform sampler2D _NormalMesh; uniform float4 _NormalMesh_ST;
        uniform sampler2D _NormalWaves2; uniform float4 _NormalWaves2_ST;
        uniform float _Alpha;
        uniform float _Refraction;
        uniform float _NormalIntensity;
        struct VertexInput {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 tangent : TANGENT;
            float2 texcoord0 : TEXCOORD0;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv0 : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float2 uv2 : TEXCOORD2;
            float4 posWorld : TEXCOORD3;
            float3 normalDir : TEXCOORD4;
            float3 tangentDir : TEXCOORD5;
            float3 bitangentDir : TEXCOORD6;
            float4 screenPos : TEXCOORD7;
            LIGHTING_COORDS(8,9)
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv0 = v.texcoord0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.normalDir = UnityObjectToWorldNormal(v.normal);
            o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
            o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
            o.posWorld = mul(unity_ObjectToWorld, v.vertex);
            float3 lightColor = _LightColor0.rgb;
            o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
            o.screenPos = o.pos;
            TRANSFER_VERTEX_TO_FRAGMENT(o)
            return o;
        }
        float4 frag(VertexOutput i) : COLOR {
            #if UNITY_UV_STARTS_AT_TOP
                float grabSign = -_ProjectionParams.x;
            #else
                float grabSign = _ProjectionParams.x;
            #endif
            i.normalDir = normalize(i.normalDir);
            i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
            i.screenPos.y *= _ProjectionParams.x;
            float4 node_5506 = _Time + _TimeEditor;
            float2 node_8344 = (i.uv0+node_5506.g*float2(0.1,0));
            float3 _NormalWaves2_var = UnpackNormal(tex2D(_NormalWaves2,TRANSFORM_TEX(node_8344, _NormalWaves2)));
            float2 node_2756 = (i.uv0+node_5506.g*float2(0.25,0));
            float3 _NormalWaves1_var = UnpackNormal(tex2D(_NormalWaves1,TRANSFORM_TEX(node_2756, _NormalWaves1)));
            float3 node_2343 = ((_NormalWaves2_var.rgb+_NormalWaves1_var.rgb)*_NormalIntensity);
            float2 node_8415 = (i.uv0+node_5506.g*float2(0.1,0));
            float4 _Waves1_var = tex2D(_Waves1,TRANSFORM_TEX(node_8415, _Waves1));
            float2 node_2158 = (i.uv0+node_5506.g*float2(0.5,0));
            float4 _Waves2_var = tex2D(_Waves2,TRANSFORM_TEX(node_2158, _Waves2));
            float3 node_566 = ((_Waves1_var.rgb+_Waves2_var.rgb)*_MultiplyWaves12);
            float4 _BottomMask_var = tex2D(_BottomMask,TRANSFORM_TEX(i.uv0, _BottomMask));
            float4 _SideMask_var = tex2D(_SideMask,TRANSFORM_TEX(i.uv0, _SideMask));
            float2 node_7927 = (i.uv0+node_5506.g*float2(0.2,0));
            float4 _Sidewaves_var = tex2D(_Sidewaves,TRANSFORM_TEX(node_7927, _Sidewaves));
            float3 node_6232 = ((((node_566*(_BottomMask_var.rgb+_bottomMaskadd1))+(1.0 - (_BottomMask_var.rgb+_BottmMaskadd2)))*(1.0 - _BottomMask_var.rgb))+(_SideMask_var.rgb*(_Sidewaves_var.rgb*_IntenseSideWave)));
            float node_1776 = (node_6232*(1.0 - _BottomMask_var.rgb)).r;
            float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction*(node_2343.rg*node_1776));
            float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
            float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            float3 _NormalMesh_var = UnpackNormal(tex2D(_NormalMesh,TRANSFORM_TEX(i.uv0, _NormalMesh)));
            float3 normalLocal = ((node_2343*node_6232)+_NormalMesh_var.rgb);
            float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
            
            float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
            i.normalDir *= nSign;
            normalDirection *= nSign;
            
            float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
            float3 lightColor = _LightColor0.rgb;
            float3 halfDirection = normalize(viewDirection+lightDirection);
// Lighting:
            float attenuation = LIGHT_ATTENUATION(i);
            float3 attenColor = attenuation * _LightColor0.xyz;
            float Pi = 3.141592654;
            float InvPi = 0.31830988618;
///// Gloss:
            float gloss = 1.0 - _Roughness; // Convert roughness to gloss
            float specPow = exp2( gloss * 10.0+1.0);
// Specular:
            float NdotL = max(0, dot( normalDirection, lightDirection ));
            float LdotH = max(0.0,dot(lightDirection, halfDirection));
            float3 diffuseColor = _BaseColor.rgb; // Need this for specular when using metallic
            float specularMonochrome;
            float3 specularColor;
            diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
            specularMonochrome = 1-specularMonochrome;
            float NdotV = max(0.0,dot( normalDirection, viewDirection ));
            float NdotH = max(0.0,dot( normalDirection, halfDirection ));
            float VdotH = max(0.0,dot( viewDirection, halfDirection ));
            float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
            float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
            float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
            float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
            float3 specular = directSpecular;
/// Diffuse:
            NdotL = max(0.0,dot( normalDirection, lightDirection ));
            half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
            float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
            float3 diffuse = directDiffuse * diffuseColor;
// Final Color:
            float3 finalColor = diffuse + specular;
            return fixed4(finalColor * (node_1776*_Alpha),0);
        }
        ENDCG
    }
    Pass {
        Name "Meta"
        Tags {
            "LightMode"="Meta"
        }
        Cull Off
        
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #define UNITY_PASS_META 1
        #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
        #define _GLOSSYENV 1
        #include "UnityCG.cginc"
        #include "Lighting.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardBRDF.cginc"
        #include "UnityMetaPass.cginc"
        #pragma fragmentoption ARB_precision_hint_fastest
        #pragma multi_compile_shadowcaster
        #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
        #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
        #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
        #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
        #pragma target 3.0
        uniform float4 _TimeEditor;
        uniform float _Metallic;
        uniform float _Roughness;
        uniform float4 _BaseColor;
        uniform sampler2D _Waves1; uniform float4 _Waves1_ST;
        uniform sampler2D _Waves2; uniform float4 _Waves2_ST;
        uniform float _MultiplyWaves12;
        uniform float _MultiplyEmissiveWave;
        uniform sampler2D _SlimWaves; uniform float4 _SlimWaves_ST;
        uniform float4 _EmissiveColor;
        struct VertexInput {
            float4 vertex : POSITION;
            float2 texcoord0 : TEXCOORD0;
            float2 texcoord1 : TEXCOORD1;
            float2 texcoord2 : TEXCOORD2;
        };
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float2 uv0 : TEXCOORD0;
            float2 uv1 : TEXCOORD1;
            float2 uv2 : TEXCOORD2;
            float4 posWorld : TEXCOORD3;
        };
        VertexOutput vert (VertexInput v) {
            VertexOutput o = (VertexOutput)0;
            o.uv0 = v.texcoord0;
            o.uv1 = v.texcoord1;
            o.uv2 = v.texcoord2;
            o.posWorld = mul(unity_ObjectToWorld, v.vertex);
            o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
            return o;
        }
        float4 frag(VertexOutput i) : SV_Target {
/// Vectors:
            float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
            UnityMetaInput o;
            UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
            
            float4 _SlimWaves_var = tex2D(_SlimWaves,TRANSFORM_TEX(i.uv0, _SlimWaves));
            float4 node_9102 = _Time + _TimeEditor;
            float2 node_8415 = (i.uv0+node_9102.g*float2(0.1,0));
            float4 _Waves1_var = tex2D(_Waves1,TRANSFORM_TEX(node_8415, _Waves1));
            float2 node_2158 = (i.uv0+node_9102.g*float2(0.5,0));
            float4 _Waves2_var = tex2D(_Waves2,TRANSFORM_TEX(node_2158, _Waves2));
            float3 node_566 = ((_Waves1_var.rgb+_Waves2_var.rgb)*_MultiplyWaves12);
            o.Emission = (_EmissiveColor.rgb*(_SlimWaves_var.rgb*(node_566*_MultiplyEmissiveWave)));
            
            float3 diffColor = _BaseColor.rgb;
            float specularMonochrome;
            float3 specColor;
            diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
            float roughness = _Roughness;
            o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
            
            return UnityMetaFragment( o );
        }
        ENDCG
    }
}
FallBack "Diffuse"
CustomEditor "ShaderForgeMaterialInspector"
}
