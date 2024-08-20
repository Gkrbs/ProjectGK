using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Reflection;
using TMPro;
using ShadowResolution = UnityEngine.Rendering.Universal.ShadowResolution;

// 퀄리티 세팅 다시 만들기
// PlayerPref 만들어서 저장하기
//defaultsetting 추가해야함

public class GraphicSetting : MonoBehaviour
{
    UniversalRenderPipelineAsset urp;
    private System.Type urpType;
    private FieldInfo shadowmapResolutionFieldInfo;

    public Volume volume;
    MotionBlur motionBlur;
    LiftGammaGain liftGammaGain;
    ColorAdjustments colorAdjustments;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    List<Resolution> res = new();
    List<string> options = new();

    public SelectUI GraphicPreset;
    public Slider BrightnessSlider;
    public Slider GammaSlider;
    public TMP_Text BrightnessText;
    public TMP_Text GammaText;
    public SelectUI ScreenMode;

    public SelectUI FrameRate;
    public SelectUI QualitySetting;
    public SelectUI MotionBlurSetting;
    public SelectUI AntiAliasing;
    public SelectUI ShadowQualityUI;
    public SelectUI ShadowDistance;

    List<float> qualityValue = new List<float>() { 0.5f, 1.0f, 2.0f };
    List<int> frameRateValue = new List<int>() { 60, 120, 144, 240, -1 };
    List<int> shadowDistanceValue = new List<int>() { 0, 50, 100, 200 };
    List<MsaaQuality> antiValue = new List<MsaaQuality>() { MsaaQuality.Disabled,
                                                                MsaaQuality._2x,
                                                                MsaaQuality._4x,
                                                                MsaaQuality._8x };
    List<ShadowResolution> shadowQualityValue = new List<ShadowResolution>() { ShadowResolution._256,
                                                                                ShadowResolution._512,
                                                                                ShadowResolution._1024,
                                                                                ShadowResolution._2048,
                                                                                ShadowResolution._4096 };

    private void Start()
    {
        urp = GraphicsSettings.renderPipelineAsset as UniversalRenderPipelineAsset;
        volume.profile.TryGet(out motionBlur);
        volume.profile.TryGet(out liftGammaGain);
        volume.profile.TryGet(out colorAdjustments);
        #region Resolution Setting
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int index = 0;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width % 16 == 0 && resolutions[i].height % 9 == 0)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                if (!options.Contains(option))
                {
                    options.Add(option);
                    res.Add(resolutions[i]);
                }
                if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = index;
                }
                index++;
            }
        }
        resolutionDropdown.AddOptions(options);
        #endregion
        QualitySettings.vSyncCount = 0;
        if (PlayerPrefs.HasKey("GraphicPreset"))
        {
            LoadValue();
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
            SetDefault(currentResolutionIndex);
        }
    }


    private void InitializeShadowMapFieldInfo()
    {
        urpType = urp.GetType();
        shadowmapResolutionFieldInfo = urpType.GetField("m_MainLightShadowmapResolution", BindingFlags.Instance | BindingFlags.NonPublic);
    }
    public ShadowResolution MainLightShadowResolution
    {
        get
        {
            if (shadowmapResolutionFieldInfo == null)
            {
                InitializeShadowMapFieldInfo();
            }
            return (ShadowResolution)shadowmapResolutionFieldInfo.GetValue(GraphicsSettings.currentRenderPipeline);
        }
        set
        {
            if (shadowmapResolutionFieldInfo == null)
            {
                InitializeShadowMapFieldInfo();
            }
            shadowmapResolutionFieldInfo.SetValue(GraphicsSettings.currentRenderPipeline, value);
        }
    }
    public void RefreshSetting()
    {
        resolutionDropdown.RefreshShownValue();
    }

    public void SetDefault(int currentResolutionIndex)
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        SetFullScreen(true);
        Application.targetFrameRate = 240;
        ScreenMode.CustomSet(1);
        FrameRate.CustomSet(3);
        SetResolution(currentResolutionIndex);
        RefreshSetting();

        GraphicPreset.CustomSet(2);
        SetGraphicPreset();
        GammaSlider.value = 0;
        GammaText.text = "50";
    }

    public void SetCustom()
    {
        if (GraphicPreset.currentIndex == 3) return;
        GraphicPreset.CustomSet(3);
        PlayerPrefs.SetInt("GraphicPreset", 3);
    }
    public void SetGraphicPreset()
    {
        switch (GraphicPreset.currentIndex)
        {
            case 0:
                QualitySetting.CustomSet(0);
                MotionBlurSetting.CustomSet(0);
                AntiAliasing.CustomSet(0);
                ShadowDistance.CustomSet(0);
                ShadowQualityUI.CustomSet(0);
                SetQuality();
                SetMotionBlur();
                SetAntiAliasing();
                SetShadowDistance();
                SetShadowQuality();
                PlayerPrefs.SetInt("GraphicPreset", 0);
                break;
            case 1:
                QualitySetting.CustomSet(0);
                MotionBlurSetting.CustomSet(0);
                AntiAliasing.CustomSet(1);
                ShadowDistance.CustomSet(2);
                ShadowQualityUI.CustomSet(3);
                SetQuality();
                SetMotionBlur();
                SetAntiAliasing();
                SetShadowDistance();
                SetShadowQuality();
                PlayerPrefs.SetInt("GraphicPreset", 1);
                break;
            case 2:
                QualitySetting.CustomSet(3);
                MotionBlurSetting.CustomSet(1);
                AntiAliasing.CustomSet(3);
                ShadowDistance.CustomSet(3);
                ShadowQualityUI.CustomSet(5);
                SetQuality();
                SetMotionBlur();
                SetAntiAliasing();
                SetShadowDistance();
                SetShadowQuality();
                PlayerPrefs.SetInt("GraphicPreset", 2);
                break;
            default:
                PlayerPrefs.SetInt("GraphicPreset", 3);
                break;
        }
    }
    public void SetBrightness(float value)
    {
        colorAdjustments.postExposure.value = value;
        BrightnessText.text = ((value + 5)/7.5 * 100).ToString("F0");
        PlayerPrefs.SetFloat("Brightness", value);
    }
    public void SetGamma(float value)
    {
        liftGammaGain.gamma.value = new Vector4(1f, 1f, 1f, value);
        GammaText.text = ((value + 0.5f) * 100).ToString("F0");
        PlayerPrefs.SetFloat("Gamma", value);
    }
    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
        PlayerPrefs.SetInt("ScreenMode", System.Convert.ToInt32(isFull));
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = res[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }


    public void SetFrameRate()
    {
        Application.targetFrameRate = frameRateValue[FrameRate.currentIndex];
        PlayerPrefs.SetInt("FrameRate", FrameRate.currentIndex);
    }
    public void SetMotionBlur()
    {
        motionBlur.active = System.Convert.ToBoolean(MotionBlurSetting.currentIndex);
        PlayerPrefs.SetInt("MotionBlur", MotionBlurSetting.currentIndex);
    }

    public void SetQuality()
    {
        urp.renderScale = qualityValue[QualitySetting.currentIndex];
        PlayerPrefs.SetInt("Quality", QualitySetting.currentIndex);

    }
    public void SetAntiAliasing()
    {
        urp.msaaSampleCount = (int)antiValue[AntiAliasing.currentIndex];
        PlayerPrefs.SetInt("AntiAliasing", AntiAliasing.currentIndex);
    }

    public void SetShadowQuality()
    {
        MainLightShadowResolution = shadowQualityValue[ShadowQualityUI.currentIndex];
        PlayerPrefs.SetInt("ShadowQuality", ShadowQualityUI.currentIndex);
    }
    public void SetShadowDistance()
    {
        urp.shadowDistance = shadowDistanceValue[ShadowDistance.currentIndex];
        PlayerPrefs.SetInt("ShadowDistance", ShadowDistance.currentIndex);
    }


    private void LoadValue()
    {
        GraphicPreset.currentIndex = PlayerPrefs.GetInt("GraphicPreset");
        
        colorAdjustments.postExposure.value = PlayerPrefs.GetFloat("Brightness");
        BrightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
        BrightnessText.text = ((BrightnessSlider.value + 10f) * 10f).ToString("F0");
        
        liftGammaGain.gamma.value = new Vector4(1f, 1f, 1f, PlayerPrefs.GetFloat("Gamma"));
        GammaSlider.value = PlayerPrefs.GetFloat("Gamma");
        GammaText.text = ((GammaSlider.value + 0.5f) * 100f).ToString("F0");

        Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("ScreenMode"));
        
        Application.targetFrameRate = frameRateValue[PlayerPrefs.GetInt("FrameRate")];
        
        Resolution resolution = res[PlayerPrefs.GetInt("Resolution")];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
        RefreshSetting();

        urp.renderScale = qualityValue[PlayerPrefs.GetInt("Quality")];

        motionBlur.active = System.Convert.ToBoolean(PlayerPrefs.GetInt("MotionBlur"));
        
        urp.msaaSampleCount = (int)antiValue[PlayerPrefs.GetInt("AntiAliasing")];
        
        MainLightShadowResolution = shadowQualityValue[PlayerPrefs.GetInt("ShadowQuality")];
        
        urp.shadowDistance = shadowDistanceValue[PlayerPrefs.GetInt("ShadowDistance")];
    }
}
