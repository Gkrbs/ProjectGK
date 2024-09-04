#define NUM_TEX_COORD_INTERPOLATORS 1
#define NUM_MATERIAL_TEXCOORDS_VERTEX 1
#define NUM_CUSTOM_VERTEX_INTERPOLATORS 0

struct Input
{
	//float3 Normal;
	float2 uv_MainTex : TEXCOORD0;
	float2 uv2_Material_Texture2D_0 : TEXCOORD1;
	float4 color : COLOR;
	float4 tangent;
	//float4 normal;
	float3 viewDir;
	float4 screenPos;
	float3 worldPos;
	//float3 worldNormal;
	float3 normal2;
};
struct SurfaceOutputStandard
{
	float3 Albedo;		// base (diffuse or specular) color
	float3 Normal;		// tangent space normal, if written
	half3 Emission;
	half Metallic;		// 0=non-metal, 1=metal
	// Smoothness is the user facing name, it should be perceptual smoothness but user should not have to deal with it.
	// Everywhere in the code you meet smoothness it is perceptual smoothness
	half Smoothness;	// 0=rough, 1=smooth
	half Occlusion;		// occlusion (default 1)
	float Alpha;		// alpha for transparencies
};

//#define HDRP 1
#define URP 1
#define UE5
//#define HAS_CUSTOMIZED_UVS 1
#define MATERIAL_TANGENTSPACENORMAL 1
//struct Material
//{
	//samplers start
SAMPLER( SamplerState_Linear_Repeat );
SAMPLER( SamplerState_Linear_Clamp );
TEXTURE2D(       Material_Texture2D_0 );
SAMPLER(  samplerMaterial_Texture2D_0 );
float4 Material_Texture2D_0_TexelSize;
float4 Material_Texture2D_0_ST;
TEXTURE2D(       Material_Texture2D_1 );
SAMPLER(  samplerMaterial_Texture2D_1 );
float4 Material_Texture2D_1_TexelSize;
float4 Material_Texture2D_1_ST;
TEXTURE2D(       Material_Texture2D_2 );
SAMPLER(  samplerMaterial_Texture2D_2 );
float4 Material_Texture2D_2_TexelSize;
float4 Material_Texture2D_2_ST;
TEXTURE2D(       Material_Texture2D_3 );
SAMPLER(  samplerMaterial_Texture2D_3 );
float4 Material_Texture2D_3_TexelSize;
float4 Material_Texture2D_3_ST;
TEXTURE2D(       Material_Texture2D_4 );
SAMPLER(  samplerMaterial_Texture2D_4 );
float4 Material_Texture2D_4_TexelSize;
float4 Material_Texture2D_4_ST;
TEXTURE2D(       Material_Texture2D_5 );
SAMPLER(  samplerMaterial_Texture2D_5 );
float4 Material_Texture2D_5_TexelSize;
float4 Material_Texture2D_5_ST;
TEXTURE2D(       Material_Texture2D_6 );
SAMPLER(  samplerMaterial_Texture2D_6 );
float4 Material_Texture2D_6_TexelSize;
float4 Material_Texture2D_6_ST;
TEXTURE2D(       Material_Texture2D_7 );
SAMPLER(  samplerMaterial_Texture2D_7 );
float4 Material_Texture2D_7_TexelSize;
float4 Material_Texture2D_7_ST;
TEXTURE2D(       Material_Texture2D_8 );
SAMPLER(  samplerMaterial_Texture2D_8 );
float4 Material_Texture2D_8_TexelSize;
float4 Material_Texture2D_8_ST;
TEXTURE2D(       Material_Texture2D_9 );
SAMPLER(  samplerMaterial_Texture2D_9 );
float4 Material_Texture2D_9_TexelSize;
float4 Material_Texture2D_9_ST;
TEXTURE2D(       Material_Texture2D_10 );
SAMPLER(  samplerMaterial_Texture2D_10 );
float4 Material_Texture2D_10_TexelSize;
float4 Material_Texture2D_10_ST;
TEXTURE2D(       Material_Texture2D_11 );
SAMPLER(  samplerMaterial_Texture2D_11 );
float4 Material_Texture2D_11_TexelSize;
float4 Material_Texture2D_11_ST;
TEXTURE2D(       Material_Texture2D_12 );
SAMPLER(  samplerMaterial_Texture2D_12 );
float4 Material_Texture2D_12_TexelSize;
float4 Material_Texture2D_12_ST;
TEXTURE2D(       Material_Texture2D_13 );
SAMPLER(  samplerMaterial_Texture2D_13 );
float4 Material_Texture2D_13_TexelSize;
float4 Material_Texture2D_13_ST;
TEXTURE2D(       Material_Texture2D_14 );
SAMPLER(  samplerMaterial_Texture2D_14 );
float4 Material_Texture2D_14_TexelSize;
float4 Material_Texture2D_14_ST;

//};

#ifdef UE5
	#define UE_LWC_RENDER_TILE_SIZE			2097152.0
	#define UE_LWC_RENDER_TILE_SIZE_SQRT	1448.15466
	#define UE_LWC_RENDER_TILE_SIZE_RSQRT	0.000690533954
	#define UE_LWC_RENDER_TILE_SIZE_RCP		4.76837158e-07
	#define UE_LWC_RENDER_TILE_SIZE_FMOD_PI		0.673652053
	#define UE_LWC_RENDER_TILE_SIZE_FMOD_2PI	0.673652053
	#define INVARIANT(X) X
	#define PI 					(3.1415926535897932)

	#include "LargeWorldCoordinates.hlsl"
#endif
struct MaterialStruct
{
	float4 PreshaderBuffer[14];
	float4 ScalarExpressions[1];
	float VTPackedPageTableUniform[2];
	float VTPackedUniform[1];
};
static SamplerState View_MaterialTextureBilinearWrapedSampler;
static SamplerState View_MaterialTextureBilinearClampedSampler;
struct ViewStruct
{
	float GameTime;
	float RealTime;
	float DeltaTime;
	float PrevFrameGameTime;
	float PrevFrameRealTime;
	float MaterialTextureMipBias;	
	float4 PrimitiveSceneData[ 40 ];
	float4 TemporalAAParams;
	float2 ViewRectMin;
	float4 ViewSizeAndInvSize;
	float MaterialTextureDerivativeMultiply;
	uint StateFrameIndexMod8;
	float FrameNumber;
	float2 FieldOfViewWideAngles;
	float4 RuntimeVirtualTextureMipLevel;
	float PreExposure;
	float4 BufferBilinearUVMinMax;
};
struct ResolvedViewStruct
{
	#ifdef UE5
		FLWCVector3 WorldCameraOrigin;
		FLWCVector3 PrevWorldCameraOrigin;
		FLWCVector3 PreViewTranslation;
		FLWCVector3 WorldViewOrigin;
	#else
		float3 WorldCameraOrigin;
		float3 PrevWorldCameraOrigin;
		float3 PreViewTranslation;
		float3 WorldViewOrigin;
	#endif
	float4 ScreenPositionScaleBias;
	float4x4 TranslatedWorldToView;
	float4x4 TranslatedWorldToCameraView;
	float4x4 TranslatedWorldToClip;
	float4x4 ViewToTranslatedWorld;
	float4x4 PrevViewToTranslatedWorld;
	float4x4 CameraViewToTranslatedWorld;
	float4 BufferBilinearUVMinMax;
	float4 XRPassthroughCameraUVs[ 2 ];
};
struct PrimitiveStruct
{
	float4x4 WorldToLocal;
	float4x4 LocalToWorld;
};

static ViewStruct View;
static ResolvedViewStruct ResolvedView;
static PrimitiveStruct Primitive;
uniform float4 View_BufferSizeAndInvSize;
uniform float4 LocalObjectBoundsMin;
uniform float4 LocalObjectBoundsMax;
static SamplerState Material_Wrap_WorldGroupSettings;
static SamplerState Material_Clamp_WorldGroupSettings;

#include "UnrealCommon.cginc"

static MaterialStruct Material;
void InitializeExpressions()
{
	Material.PreshaderBuffer[0] = float4(4.000000,0.000000,5.000000,5.521872);//(Unknown)
	Material.PreshaderBuffer[1] = float4(4.000000,0.000000,1.300000,-0.300000);//(Unknown)
	Material.PreshaderBuffer[2] = float4(0.000000,5.000000,0.537204,-0.178126);//(Unknown)
	Material.PreshaderBuffer[3] = float4(0.000000,0.000000,0.000000,0.000000);//(Unknown)
	Material.PreshaderBuffer[4] = float4(0.803922,0.886275,0.878431,0.000000);//(Unknown)
	Material.PreshaderBuffer[5] = float4(1.000000,0.776667,0.904273,0.913726);//(Unknown)
	Material.PreshaderBuffer[6] = float4(0.000000,1.000000,0.000000,0.000000);//(Unknown)
	Material.PreshaderBuffer[7] = float4(0.875000,0.875000,0.875000,0.000000);//(Unknown)
	Material.PreshaderBuffer[8] = float4(1.000000,1.000000,0.000000,0.000000);//(Unknown)
	Material.PreshaderBuffer[9] = float4(0.036458,0.032986,0.028768,0.600000);//(Unknown)
	Material.PreshaderBuffer[10] = float4(0.000000,0.000000,0.000000,0.000000);//(Unknown)
	Material.PreshaderBuffer[11] = float4(0.127273,0.218750,0.063636,1.000000);//(Unknown)
	Material.PreshaderBuffer[12] = float4(0.300000,1.500000,0.150000,1.000000);//(Unknown)
	Material.PreshaderBuffer[13] = float4(1.000000,1.000000,0.000000,0.000000);//(Unknown)
}float3 GetMaterialWorldPositionOffset(FMaterialVertexParameters Parameters)
{
	return MaterialFloat3(0.00000000,0.00000000,0.00000000);;
}
void CalcPixelMaterialInputs(in out FMaterialPixelParameters Parameters, in out FPixelMaterialInputs PixelMaterialInputs)
{
	//WorldAligned texturing & others use normals & stuff that think Z is up
	Parameters.TangentToWorld[0] = Parameters.TangentToWorld[0].xzy;
	Parameters.TangentToWorld[1] = Parameters.TangentToWorld[1].xzy;
	Parameters.TangentToWorld[2] = Parameters.TangentToWorld[2].xzy;

	float3 WorldNormalCopy = Parameters.WorldNormal;

	// Initial calculations (required for Normal)
	MaterialFloat2 Local0 = Parameters.TexCoords[0].xy;
	MaterialFloat Local1 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local0), 2);
	MaterialFloat4 Local2 = UnpackNormalMap(Texture2DSample(Material_Texture2D_0,GetMaterialSharedSampler(samplerMaterial_Texture2D_0,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local0)));
	MaterialFloat Local3 = MaterialStoreTexSample(Parameters, Local2, 2);
	MaterialFloat Local4 = (Local2.rgb.b + 1.00000000);
	MaterialFloat3 Local5 = WSMultiplyVector(MaterialFloat3(1.00000000,0.00000000,0.00000000).rgb, GetInstanceToWorld(Parameters));
	MaterialFloat3 Local6 = (((MaterialFloat3)0.00000000) - Local5);
	MaterialFloat Local7 = length(Local6);
	MaterialFloat Local8 = (Material.PreshaderBuffer[0].x * DERIV_BASE_VALUE(Local7));
	MaterialFloat2 Local9 = (DERIV_BASE_VALUE(Local0) * ((MaterialFloat2)DERIV_BASE_VALUE(Local8)));
	MaterialFloat2 Local10 = (((MaterialFloat2)Material.PreshaderBuffer[0].y) + DERIV_BASE_VALUE(Local9));
	MaterialFloat Local11 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local10), 6);
	MaterialFloat4 Local12 = UnpackNormalMap(Texture2DSample(Material_Texture2D_1,GetMaterialSharedSampler(samplerMaterial_Texture2D_1,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local10)));
	MaterialFloat Local13 = MaterialStoreTexSample(Parameters, Local12, 6);
	MaterialFloat Local14 = (Material.PreshaderBuffer[0].z * DERIV_BASE_VALUE(Local7));
	MaterialFloat2 Local15 = (DERIV_BASE_VALUE(Local0) * ((MaterialFloat2)DERIV_BASE_VALUE(Local14)));
	MaterialFloat2 Local16 = (((MaterialFloat2)Material.PreshaderBuffer[0].w) + DERIV_BASE_VALUE(Local15));
	MaterialFloat Local17 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local16), 6);
	MaterialFloat4 Local18 = UnpackNormalMap(Texture2DSample(Material_Texture2D_2,GetMaterialSharedSampler(samplerMaterial_Texture2D_2,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local16)));
	MaterialFloat Local19 = MaterialStoreTexSample(Parameters, Local18, 6);
	MaterialFloat Local20 = (Material.PreshaderBuffer[1].x * DERIV_BASE_VALUE(Local7));
	MaterialFloat2 Local21 = (DERIV_BASE_VALUE(Local0) * ((MaterialFloat2)DERIV_BASE_VALUE(Local20)));
	MaterialFloat2 Local22 = (((MaterialFloat2)Material.PreshaderBuffer[1].y) + DERIV_BASE_VALUE(Local21));
	MaterialFloat Local23 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local22), 7);
	MaterialFloat4 Local24 = UnpackNormalMap(Texture2DSample(Material_Texture2D_3,GetMaterialSharedSampler(samplerMaterial_Texture2D_3,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local22)));
	MaterialFloat Local25 = MaterialStoreTexSample(Parameters, Local24, 7);
	MaterialFloat Local26 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local0), 10);
	MaterialFloat4 Local27 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_4,GetMaterialSharedSampler(samplerMaterial_Texture2D_4,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local0)));
	MaterialFloat Local28 = MaterialStoreTexSample(Parameters, Local27, 10);
	MaterialFloat Local29 = lerp(Material.PreshaderBuffer[1].w,Material.PreshaderBuffer[1].z,Local27.r);
	MaterialFloat Local30 = saturate(Local29);
	MaterialFloat3 Local31 = lerp(Local18.rgb,Local24.rgb,Local30.r);
	MaterialFloat Local32 = (1.00000000 - Local27.b);
	MaterialFloat Local33 = lerp(Material.PreshaderBuffer[1].w,Material.PreshaderBuffer[1].z,Local32);
	MaterialFloat Local34 = saturate(Local33);
	MaterialFloat3 Local35 = lerp(Local12.rgb,Local31,Local34.r);
	MaterialFloat2 Local36 = (Local35.rg * ((MaterialFloat2)-1.00000000));
	MaterialFloat Local37 = dot(MaterialFloat3(Local2.rgb.rg,Local4),MaterialFloat3(Local36,Local35.b));
	MaterialFloat3 Local38 = (MaterialFloat3(Local2.rgb.rg,Local4) * ((MaterialFloat3)Local37));
	MaterialFloat3 Local39 = (((MaterialFloat3)Local4) * MaterialFloat3(Local36,Local35.b));
	MaterialFloat3 Local40 = (Local38 - Local39);
	MaterialFloat3 Local41 = lerp(Local40,MaterialFloat3(0.00000000,0.00000000,1.00000000).rgb,Material.PreshaderBuffer[2].x);
	MaterialFloat Local42 = (Material.PreshaderBuffer[2].y * DERIV_BASE_VALUE(Local7));
	MaterialFloat2 Local43 = (DERIV_BASE_VALUE(Local0) * ((MaterialFloat2)DERIV_BASE_VALUE(Local42)));
	MaterialFloat Local44 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local43), 12);
	MaterialFloat4 Local45 = UnpackNormalMap(Texture2DSample(Material_Texture2D_5,GetMaterialSharedSampler(samplerMaterial_Texture2D_5,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local43)));
	MaterialFloat Local46 = MaterialStoreTexSample(Parameters, Local45, 12);
	MaterialFloat3 Local47 = mul(MaterialFloat3(0.00000000,0.00000000,1.00000000).rgb, Parameters.TangentToWorld);
	MaterialFloat3 Local48 = normalize(Local47);
	MaterialFloat Local49 = dot(DERIV_BASE_VALUE(Local48),normalize(MaterialFloat3(0.00000000,0.00000000,1.00000000).rgb));
	MaterialFloat Local50 = (DERIV_BASE_VALUE(Local49) * 0.50000000);
	MaterialFloat Local51 = (DERIV_BASE_VALUE(Local50) + 0.50000000);
	MaterialFloat Local52 = (DERIV_BASE_VALUE(Local51) * Material.PreshaderBuffer[2].z);
	MaterialFloat Local53 = (DERIV_BASE_VALUE(Local52) + Material.PreshaderBuffer[2].w);
	MaterialFloat Local54 = saturate(DERIV_BASE_VALUE(Local53));
	MaterialFloat3 Local55 = lerp(Local41,Local45.rgb,DERIV_BASE_VALUE(Local54));

	// The Normal is a special case as it might have its own expressions and also be used to calculate other inputs, so perform the assignment here
	PixelMaterialInputs.Normal = Local55;


#if TEMPLATE_USES_SUBSTRATE
	Parameters.SubstratePixelFootprint = SubstrateGetPixelFootprint(Parameters.WorldPosition_CamRelative, GetRoughnessFromNormalCurvature(Parameters));
	Parameters.SharedLocalBases = SubstrateInitialiseSharedLocalBases();
	Parameters.SubstrateTree = GetInitialisedSubstrateTree();
#if SUBSTRATE_USE_FULLYSIMPLIFIED_MATERIAL == 1
	Parameters.SharedLocalBasesFullySimplified = SubstrateInitialiseSharedLocalBases();
	Parameters.SubstrateTreeFullySimplified = GetInitialisedSubstrateTree();
#endif
#endif

	// Note that here MaterialNormal can be in world space or tangent space
	float3 MaterialNormal = GetMaterialNormal(Parameters, PixelMaterialInputs);

#if MATERIAL_TANGENTSPACENORMAL

#if FEATURE_LEVEL >= FEATURE_LEVEL_SM4
	// Mobile will rely on only the final normalize for performance
	MaterialNormal = normalize(MaterialNormal);
#endif

	// normalizing after the tangent space to world space conversion improves quality with sheared bases (UV layout to WS causes shrearing)
	// use full precision normalize to avoid overflows
	Parameters.WorldNormal = TransformTangentNormalToWorld(Parameters.TangentToWorld, MaterialNormal);

#else //MATERIAL_TANGENTSPACENORMAL

	Parameters.WorldNormal = normalize(MaterialNormal);

#endif //MATERIAL_TANGENTSPACENORMAL

#if MATERIAL_TANGENTSPACENORMAL || TWO_SIDED_WORLD_SPACE_SINGLELAYERWATER_NORMAL
	// flip the normal for backfaces being rendered with a two-sided material
	Parameters.WorldNormal *= Parameters.TwoSidedSign;
#endif

	Parameters.ReflectionVector = ReflectionAboutCustomWorldNormal(Parameters, Parameters.WorldNormal, false);

#if !PARTICLE_SPRITE_FACTORY
	Parameters.Particle.MotionBlurFade = 1.0f;
#endif // !PARTICLE_SPRITE_FACTORY

	// Now the rest of the inputs
	MaterialFloat3 Local56 = lerp(MaterialFloat3(0.00000000,0.00000000,0.00000000),Material.PreshaderBuffer[3].yzw,Material.PreshaderBuffer[3].x);
	MaterialFloat Local57 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local10), 14);
	MaterialFloat4 Local58 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_6,GetMaterialSharedSampler(samplerMaterial_Texture2D_6,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local10)));
	MaterialFloat Local59 = MaterialStoreTexSample(Parameters, Local58, 14);
	MaterialFloat3 Local60 = (Material.PreshaderBuffer[4].xyz * Local58.rgb);
	MaterialFloat Local61 = dot(Local60,MaterialFloat3(0.30000001,0.58999997,0.11000000));
	MaterialFloat3 Local62 = lerp(Local60,((MaterialFloat3)Local61),Material.PreshaderBuffer[4].w);
	MaterialFloat3 Local63 = (Local62 * ((MaterialFloat3)Material.PreshaderBuffer[5].x));
	MaterialFloat Local64 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local16), 5);
	MaterialFloat4 Local65 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_7,GetMaterialSharedSampler(samplerMaterial_Texture2D_7,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local16)));
	MaterialFloat Local66 = MaterialStoreTexSample(Parameters, Local65, 5);
	MaterialFloat3 Local67 = (Material.PreshaderBuffer[5].yzw * Local65.rgb);
	MaterialFloat Local68 = dot(Local67,MaterialFloat3(0.30000001,0.58999997,0.11000000));
	MaterialFloat3 Local69 = lerp(Local67,((MaterialFloat3)Local68),Material.PreshaderBuffer[6].x);
	MaterialFloat3 Local70 = (Local69 * ((MaterialFloat3)Material.PreshaderBuffer[6].y));
	MaterialFloat Local71 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local22), 4);
	MaterialFloat4 Local72 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_8,GetMaterialSharedSampler(samplerMaterial_Texture2D_8,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local22)));
	MaterialFloat Local73 = MaterialStoreTexSample(Parameters, Local72, 4);
	MaterialFloat3 Local74 = (Material.PreshaderBuffer[7].xyz * Local72.rgb);
	MaterialFloat Local75 = dot(Local74,MaterialFloat3(0.30000001,0.58999997,0.11000000));
	MaterialFloat3 Local76 = lerp(Local74,((MaterialFloat3)Local75),Material.PreshaderBuffer[7].w);
	MaterialFloat3 Local77 = (Local76 * ((MaterialFloat3)Material.PreshaderBuffer[8].x));
	MaterialFloat3 Local78 = lerp(Local70,Local77,Local30.r);
	MaterialFloat3 Local79 = lerp(Local63,Local78,Local34.r);
	MaterialFloat Local80 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local0), 3);
	MaterialFloat4 Local81 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_9,GetMaterialSharedSampler(samplerMaterial_Texture2D_9,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local0)));
	MaterialFloat Local82 = MaterialStoreTexSample(Parameters, Local81, 3);
	MaterialFloat Local83 = (Material.PreshaderBuffer[8].y * Local81.g);
	MaterialFloat3 Local84 = lerp(Local79,Material.PreshaderBuffer[9].xyz,Local83);
	MaterialFloat Local85 = (Material.PreshaderBuffer[9].w * Local27.a);
	MaterialFloat3 Local86 = lerp(Local84,Material.PreshaderBuffer[10].xyz,Local85);
	MaterialFloat Local87 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local43), 11);
	MaterialFloat4 Local88 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_10,GetMaterialSharedSampler(samplerMaterial_Texture2D_10,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local43)));
	MaterialFloat Local89 = MaterialStoreTexSample(Parameters, Local88, 11);
	MaterialFloat3 Local90 = (Material.PreshaderBuffer[11].xyz * Local88.rgb);
	MaterialFloat3 Local91 = (((MaterialFloat3)Material.PreshaderBuffer[11].w) * Local90);
	MaterialFloat Local92 = dot(WorldNormalCopy,normalize(MaterialFloat3(0.00000000,0.00000000,1.00000000).rgb));
	MaterialFloat Local93 = (Local92 * 0.50000000);
	MaterialFloat Local94 = (Local93 + 0.50000000);
	MaterialFloat Local95 = (Local94 * Material.PreshaderBuffer[2].z);
	MaterialFloat Local96 = (Local95 + Material.PreshaderBuffer[2].w);
	MaterialFloat Local97 = saturate(Local96);
	MaterialFloat3 Local98 = lerp(Local86,Local91,Local97);
	MaterialFloat3 Local99 = PositiveClampedPow(Local98,((MaterialFloat3)Material.PreshaderBuffer[12].x));
	MaterialFloat3 Local100 = saturate(Local99);
	MaterialFloat3 Local101 = (Local100 * ((MaterialFloat3)Material.PreshaderBuffer[12].y));
	MaterialFloat3 Local102 = (((MaterialFloat3)1.00000000) - Local101);
	MaterialFloat3 Local103 = (((MaterialFloat3)Material.PreshaderBuffer[12].z) * Local102);
	MaterialFloat Local104 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local0), 15);
	MaterialFloat4 Local105 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_11,GetMaterialSharedSampler(samplerMaterial_Texture2D_11,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local0)));
	MaterialFloat Local106 = MaterialStoreTexSample(Parameters, Local105, 15);
	MaterialFloat Local107 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local16), 9);
	MaterialFloat4 Local108 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_12,GetMaterialSharedSampler(samplerMaterial_Texture2D_12,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local16)));
	MaterialFloat Local109 = MaterialStoreTexSample(Parameters, Local108, 9);
	MaterialFloat Local110 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local22), 8);
	MaterialFloat4 Local111 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_13,GetMaterialSharedSampler(samplerMaterial_Texture2D_13,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local22)));
	MaterialFloat Local112 = MaterialStoreTexSample(Parameters, Local111, 8);
	MaterialFloat Local113 = lerp(Local108.r,Local111.r,Local30.r);
	MaterialFloat3 Local114 = lerp(Local105.rgb,((MaterialFloat3)Local113),Local34.r);
	MaterialFloat Local115 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local43), 13);
	MaterialFloat4 Local116 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_14,GetMaterialSharedSampler(samplerMaterial_Texture2D_14,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local43)));
	MaterialFloat Local117 = MaterialStoreTexSample(Parameters, Local116, 13);
	MaterialFloat3 Local118 = lerp(Local114,((MaterialFloat3)Local116.r),Local97);
	MaterialFloat Local119 = (1.00000000 - Local81.r);
	MaterialFloat Local120 = (Local119 * 2.00000000);
	MaterialFloat Local121 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local0), 9);
	MaterialFloat4 Local122 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_12,GetMaterialSharedSampler(samplerMaterial_Texture2D_12,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local0)));
	MaterialFloat Local123 = MaterialStoreTexSample(Parameters, Local122, 9);
	MaterialFloat Local124 = MaterialStoreTexCoordScale(Parameters, DERIV_BASE_VALUE(Local0), 8);
	MaterialFloat4 Local125 = ProcessMaterialColorTextureLookup(Texture2DSample(Material_Texture2D_13,GetMaterialSharedSampler(samplerMaterial_Texture2D_13,View_MaterialTextureBilinearWrapedSampler),DERIV_BASE_VALUE(Local0)));
	MaterialFloat Local126 = MaterialStoreTexSample(Parameters, Local125, 8);
	MaterialFloat Local127 = lerp(Local122.g,Local125.g,Local30.r);
	MaterialFloat Local128 = lerp(Local105.g,Local127,Local34.r);
	MaterialFloat Local129 = (1.00000000 - Local128);
	MaterialFloat Local130 = (Local120 * Local129);
	MaterialFloat Local131 = (1.00000000 - Local130);
	MaterialFloat Local132 = (Local81.r * 2.00000000);
	MaterialFloat Local133 = (Local132 * Local128);
	MaterialFloat Local134 = select((Local81.r.r >= 0.50000000), Local131.r, Local133.r);
	MaterialFloat3 Local135 = lerp(MaterialFloat3(MaterialFloat2(Local134,Local134),Local134),((MaterialFloat3)Local116.g),Local97);
	MaterialFloat3 Local136 = lerp(Local135,((MaterialFloat3)Material.PreshaderBuffer[13].x),Material.PreshaderBuffer[12].w);
	MaterialFloat3 Local137 = PositiveClampedPow(Local136,((MaterialFloat3)Material.PreshaderBuffer[13].y));

	PixelMaterialInputs.EmissiveColor = Local56;
	PixelMaterialInputs.Opacity = 1.00000000;
	PixelMaterialInputs.OpacityMask = 1.00000000;
	PixelMaterialInputs.BaseColor = Local98;
	PixelMaterialInputs.Metallic = 0.00000000;
	PixelMaterialInputs.Specular = Local103;
	PixelMaterialInputs.Roughness = Local118;
	PixelMaterialInputs.Anisotropy = 0.00000000;
	PixelMaterialInputs.Normal = Local55;
	PixelMaterialInputs.Tangent = MaterialFloat3(1.00000000,0.00000000,0.00000000);
	PixelMaterialInputs.Subsurface = 0;
	PixelMaterialInputs.AmbientOcclusion = Local137;
	PixelMaterialInputs.Refraction = 0;
	PixelMaterialInputs.PixelDepthOffset = 0.00000000;
	PixelMaterialInputs.ShadingModel = 1;
	PixelMaterialInputs.FrontMaterial = GetInitialisedSubstrateData();
	PixelMaterialInputs.SurfaceThickness = 0.01000000;
	PixelMaterialInputs.Displacement = 0.50000000;


#if MATERIAL_USES_ANISOTROPY
	Parameters.WorldTangent = CalculateAnisotropyTangent(Parameters, PixelMaterialInputs);
#else
	Parameters.WorldTangent = 0;
#endif
}

#define UnityObjectToWorldDir TransformObjectToWorld

void SetupCommonData( int Parameters_PrimitiveId )
{
	View_MaterialTextureBilinearWrapedSampler = SamplerState_Linear_Repeat;
	View_MaterialTextureBilinearClampedSampler = SamplerState_Linear_Clamp;

	Material_Wrap_WorldGroupSettings = SamplerState_Linear_Repeat;
	Material_Clamp_WorldGroupSettings = SamplerState_Linear_Clamp;

	View.GameTime = View.RealTime = _Time.y;// _Time is (t/20, t, t*2, t*3)
	View.PrevFrameGameTime = View.GameTime - unity_DeltaTime.x;//(dt, 1/dt, smoothDt, 1/smoothDt)
	View.PrevFrameRealTime = View.RealTime;
	View.DeltaTime = unity_DeltaTime.x;
	View.MaterialTextureMipBias = 0.0;
	View.TemporalAAParams = float4( 0, 0, 0, 0 );
	View.ViewRectMin = float2( 0, 0 );
	View.ViewSizeAndInvSize = View_BufferSizeAndInvSize;
	View.MaterialTextureDerivativeMultiply = 1.0f;
	View.StateFrameIndexMod8 = 0;
	View.FrameNumber = (int)_Time.y;
	View.FieldOfViewWideAngles = float2( PI * 0.42f, PI * 0.42f );//75degrees, default unity
	View.RuntimeVirtualTextureMipLevel = float4( 0, 0, 0, 0 );
	View.PreExposure = 0;
	View.BufferBilinearUVMinMax = float4(
		View_BufferSizeAndInvSize.z * ( 0 + 0.5 ),//EffectiveViewRect.Min.X
		View_BufferSizeAndInvSize.w * ( 0 + 0.5 ),//EffectiveViewRect.Min.Y
		View_BufferSizeAndInvSize.z * ( View_BufferSizeAndInvSize.x - 0.5 ),//EffectiveViewRect.Max.X
		View_BufferSizeAndInvSize.w * ( View_BufferSizeAndInvSize.y - 0.5 ) );//EffectiveViewRect.Max.Y

	for( int i2 = 0; i2 < 40; i2++ )
		View.PrimitiveSceneData[ i2 ] = float4( 0, 0, 0, 0 );

	float4x4 LocalToWorld = transpose( UNITY_MATRIX_M );
    LocalToWorld[3] = float4(ToUnrealPos(LocalToWorld[3]), LocalToWorld[3].w);
	float4x4 WorldToLocal = transpose( UNITY_MATRIX_I_M );
	float4x4 ViewMatrix = transpose( UNITY_MATRIX_V );
	float4x4 InverseViewMatrix = transpose( UNITY_MATRIX_I_V );
	float4x4 ViewProjectionMatrix = transpose( UNITY_MATRIX_VP );
	uint PrimitiveBaseOffset = Parameters_PrimitiveId * PRIMITIVE_SCENE_DATA_STRIDE;
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 0 ] = LocalToWorld[ 0 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 1 ] = LocalToWorld[ 1 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 2 ] = LocalToWorld[ 2 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 3 ] = LocalToWorld[ 3 ];//LocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 5 ] = float4( ToUnrealPos( SHADERGRAPH_OBJECT_POSITION ), 100.0 );//ObjectWorldPosition
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 6 ] = WorldToLocal[ 0 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 7 ] = WorldToLocal[ 1 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 8 ] = WorldToLocal[ 2 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 9 ] = WorldToLocal[ 3 ];//WorldToLocal
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 10 ] = LocalToWorld[ 0 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 11 ] = LocalToWorld[ 1 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 12 ] = LocalToWorld[ 2 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 13 ] = LocalToWorld[ 3 ];//PreviousLocalToWorld
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 18 ] = float4( ToUnrealPos( SHADERGRAPH_OBJECT_POSITION ), 0 );//ActorWorldPosition
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 19 ] = LocalObjectBoundsMax - LocalObjectBoundsMin;//ObjectBounds
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 21 ] = mul( LocalToWorld, float3( 1, 0, 0 ) );
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 23 ] = LocalObjectBoundsMin;//LocalObjectBoundsMin 
	View.PrimitiveSceneData[ PrimitiveBaseOffset + 24 ] = LocalObjectBoundsMax;//LocalObjectBoundsMax

#ifdef UE5
	ResolvedView.WorldCameraOrigin = LWCPromote( ToUnrealPos( _WorldSpaceCameraPos.xyz ) );
	ResolvedView.PreViewTranslation = LWCPromote( float3( 0, 0, 0 ) );
	ResolvedView.WorldViewOrigin = LWCPromote( float3( 0, 0, 0 ) );
#else
	ResolvedView.WorldCameraOrigin = ToUnrealPos( _WorldSpaceCameraPos.xyz );
	ResolvedView.PreViewTranslation = float3( 0, 0, 0 );
	ResolvedView.WorldViewOrigin = float3( 0, 0, 0 );
#endif
	ResolvedView.PrevWorldCameraOrigin = ResolvedView.WorldCameraOrigin;
	ResolvedView.ScreenPositionScaleBias = float4( 1, 1, 0, 0 );
	ResolvedView.TranslatedWorldToView		 = ViewMatrix;
	ResolvedView.TranslatedWorldToCameraView = ViewMatrix;
	ResolvedView.TranslatedWorldToClip		 = ViewProjectionMatrix;
	ResolvedView.ViewToTranslatedWorld		 = InverseViewMatrix;
	ResolvedView.PrevViewToTranslatedWorld = ResolvedView.ViewToTranslatedWorld;
	ResolvedView.CameraViewToTranslatedWorld = InverseViewMatrix;
	ResolvedView.BufferBilinearUVMinMax = View.BufferBilinearUVMinMax;
	Primitive.WorldToLocal = WorldToLocal;
	Primitive.LocalToWorld = LocalToWorld;
}
#define VS_USES_UNREAL_SPACE 1
float3 PrepareAndGetWPO( float4 VertexColor, float3 UnrealWorldPos, float3 UnrealNormal, float4 InTangent,
						 float4 UV0, float4 UV1 )
{
	InitializeExpressions();
	FMaterialVertexParameters Parameters = (FMaterialVertexParameters)0;

	float3 InWorldNormal = UnrealNormal;
	float4 tangentWorld = InTangent;
	tangentWorld.xyz = normalize( tangentWorld.xyz );
	//float3x3 tangentToWorld = CreateTangentToWorldPerVertex( InWorldNormal, tangentWorld.xyz, tangentWorld.w );
	Parameters.TangentToWorld = float3x3( normalize( cross( InWorldNormal, tangentWorld.xyz ) * tangentWorld.w ), tangentWorld.xyz, InWorldNormal );

	
	#ifdef VS_USES_UNREAL_SPACE
		UnrealWorldPos = ToUnrealPos( UnrealWorldPos );
	#endif
	Parameters.WorldPosition = UnrealWorldPos;
	#ifdef VS_USES_UNREAL_SPACE
		Parameters.TangentToWorld[ 0 ] = Parameters.TangentToWorld[ 0 ].xzy;
		Parameters.TangentToWorld[ 1 ] = Parameters.TangentToWorld[ 1 ].xzy;
		Parameters.TangentToWorld[ 2 ] = Parameters.TangentToWorld[ 2 ].xzy;//WorldAligned texturing uses normals that think Z is up
	#endif

	Parameters.VertexColor = VertexColor;

#if NUM_MATERIAL_TEXCOORDS_VERTEX > 0			
	Parameters.TexCoords[ 0 ] = float2( UV0.x, UV0.y );
#endif
#if NUM_MATERIAL_TEXCOORDS_VERTEX > 1
	Parameters.TexCoords[ 1 ] = float2( UV1.x, UV1.y );
#endif
#if NUM_MATERIAL_TEXCOORDS_VERTEX > 2
	for( int i = 2; i < NUM_TEX_COORD_INTERPOLATORS; i++ )
	{
		Parameters.TexCoords[ i ] = float2( UV0.x, UV0.y );
	}
#endif

	Parameters.PrimitiveId = 0;

	SetupCommonData( Parameters.PrimitiveId );

#ifdef UE5
	Parameters.PrevFrameLocalToWorld = MakeLWCMatrix( float3( 0, 0, 0 ), Primitive.LocalToWorld );
#else
	Parameters.PrevFrameLocalToWorld = Primitive.LocalToWorld;
#endif
	
	float3 Offset = float3( 0, 0, 0 );
	Offset = GetMaterialWorldPositionOffset( Parameters );
	#ifdef VS_USES_UNREAL_SPACE
		//Convert from unreal units to unity
		Offset /= float3( 100, 100, 100 );
		Offset = Offset.xzy;
	#endif
	return Offset;
}

void SurfaceReplacement( Input In, out SurfaceOutputStandard o )
{
	InitializeExpressions();

	float3 Z3 = float3( 0, 0, 0 );
	float4 Z4 = float4( 0, 0, 0, 0 );

	float3 UnrealWorldPos = float3( In.worldPos.x, In.worldPos.y, In.worldPos.z );

	float3 UnrealNormal = In.normal2;	

	FMaterialPixelParameters Parameters = (FMaterialPixelParameters)0;
#if NUM_TEX_COORD_INTERPOLATORS > 0			
	Parameters.TexCoords[ 0 ] = float2( In.uv_MainTex.x, 1.0 - In.uv_MainTex.y );
#endif
#if NUM_TEX_COORD_INTERPOLATORS > 1
	Parameters.TexCoords[ 1 ] = float2( In.uv2_Material_Texture2D_0.x, 1.0 - In.uv2_Material_Texture2D_0.y );
#endif
#if NUM_TEX_COORD_INTERPOLATORS > 2
	for( int i = 2; i < NUM_TEX_COORD_INTERPOLATORS; i++ )
	{
		Parameters.TexCoords[ i ] = float2( In.uv_MainTex.x, 1.0 - In.uv_MainTex.y );
	}
#endif
	Parameters.VertexColor = In.color;
	Parameters.WorldNormal = UnrealNormal;
	Parameters.ReflectionVector = half3( 0, 0, 1 );
	Parameters.CameraVector = normalize( _WorldSpaceCameraPos.xyz - UnrealWorldPos.xyz );
	//Parameters.CameraVector = mul( ( float3x3 )unity_CameraToWorld, float3( 0, 0, 1 ) ) * -1;
	Parameters.LightVector = half3( 0, 0, 0 );
	//float4 screenpos = In.screenPos;
	//screenpos /= screenpos.w;
	Parameters.SvPosition = In.screenPos;
	Parameters.ScreenPosition = Parameters.SvPosition;

	Parameters.UnMirrored = 1;

	Parameters.TwoSidedSign = 1;


	float3 InWorldNormal = UnrealNormal;	
	float4 tangentWorld = In.tangent;
	tangentWorld.xyz = normalize( tangentWorld.xyz );
	//float3x3 tangentToWorld = CreateTangentToWorldPerVertex( InWorldNormal, tangentWorld.xyz, tangentWorld.w );
	Parameters.TangentToWorld = float3x3( normalize( cross( InWorldNormal, tangentWorld.xyz ) * tangentWorld.w ), tangentWorld.xyz, InWorldNormal );

	//WorldAlignedTexturing in UE relies on the fact that coords there are 100x larger, prepare values for that
	//but watch out for any computation that might get skewed as a side effect
	UnrealWorldPos = ToUnrealPos( UnrealWorldPos );
	
	Parameters.AbsoluteWorldPosition = UnrealWorldPos;
	Parameters.WorldPosition_CamRelative = UnrealWorldPos;
	Parameters.WorldPosition_NoOffsets = UnrealWorldPos;

	Parameters.WorldPosition_NoOffsets_CamRelative = Parameters.WorldPosition_CamRelative;
	Parameters.LightingPositionOffset = float3( 0, 0, 0 );

	Parameters.AOMaterialMask = 0;

	Parameters.Particle.RelativeTime = 0;
	Parameters.Particle.MotionBlurFade;
	Parameters.Particle.Random = 0;
	Parameters.Particle.Velocity = half4( 1, 1, 1, 1 );
	Parameters.Particle.Color = half4( 1, 1, 1, 1 );
	Parameters.Particle.TranslatedWorldPositionAndSize = float4( UnrealWorldPos, 0 );
	Parameters.Particle.MacroUV = half4( 0, 0, 1, 1 );
	Parameters.Particle.DynamicParameter = half4( 0, 0, 0, 0 );
	Parameters.Particle.LocalToWorld = float4x4( Z4, Z4, Z4, Z4 );
	Parameters.Particle.Size = float2( 1, 1 );
	Parameters.Particle.SubUVCoords[ 0 ] = Parameters.Particle.SubUVCoords[ 1 ] = float2( 0, 0 );
	Parameters.Particle.SubUVLerp = 0.0;
	Parameters.TexCoordScalesParams = float2( 0, 0 );
	Parameters.PrimitiveId = 0;
	Parameters.VirtualTextureFeedback = 0;

	FPixelMaterialInputs PixelMaterialInputs = (FPixelMaterialInputs)0;
	PixelMaterialInputs.Normal = float3( 0, 0, 1 );
	PixelMaterialInputs.ShadingModel = 0;
	PixelMaterialInputs.FrontMaterial = 0;

	SetupCommonData( Parameters.PrimitiveId );
	//CustomizedUVs
	#if NUM_TEX_COORD_INTERPOLATORS > 0 && HAS_CUSTOMIZED_UVS
		float2 OutTexCoords[ NUM_TEX_COORD_INTERPOLATORS ];
		//Prevent uninitialized reads
		for( int i = 0; i < NUM_TEX_COORD_INTERPOLATORS; i++ )
		{
			OutTexCoords[ i ] = float2( 0, 0 );
		}
		GetMaterialCustomizedUVs( Parameters, OutTexCoords );
		for( int i = 0; i < NUM_TEX_COORD_INTERPOLATORS; i++ )
		{
			Parameters.TexCoords[ i ] = OutTexCoords[ i ];
		}
	#endif
	//<-
	CalcPixelMaterialInputs( Parameters, PixelMaterialInputs );

	#define HAS_WORLDSPACE_NORMAL 0
	#if HAS_WORLDSPACE_NORMAL
		PixelMaterialInputs.Normal = mul( PixelMaterialInputs.Normal, (MaterialFloat3x3)( transpose( Parameters.TangentToWorld ) ) );
	#endif

	o.Albedo = PixelMaterialInputs.BaseColor.rgb;
	o.Alpha = PixelMaterialInputs.Opacity;
	if( PixelMaterialInputs.OpacityMask < 0.333 ) discard;

	o.Metallic = PixelMaterialInputs.Metallic;
	o.Smoothness = 1.0 - PixelMaterialInputs.Roughness;
	o.Normal = normalize( PixelMaterialInputs.Normal );
	o.Emission = PixelMaterialInputs.EmissiveColor.rgb;
	o.Occlusion = PixelMaterialInputs.AmbientOcclusion;

	//BLEND_ADDITIVE o.Alpha = ( o.Emission.r + o.Emission.g + o.Emission.b ) / 3;
}