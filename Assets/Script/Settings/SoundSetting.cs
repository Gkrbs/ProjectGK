using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundSetting : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider BackgroundSlider;
    public Slider EffectSlider;
    //public Slider CharacterSlider;
    public Slider VoiceSlider;

    public TMP_Text masterValue;
    public TMP_Text BackgroundValue;
    public TMP_Text EffectValue;
    //public TMP_Text CharacterValue;
    public TMP_Text VoiceValue;
    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMaster();
            SetBackground();
            SetEffect();
            //SetCharacter();
            SetVoice();
        }
    }

    public void SetMaster()
    {
        float volume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        masterValue.text = (volume * 100).ToString("F0");
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
    public void SetBackground()
    {
        float volume = BackgroundSlider.value;
        audioMixer.SetFloat("Background", Mathf.Log10(volume) * 20);
        BackgroundValue.text = (volume * 100).ToString("F0");
        PlayerPrefs.SetFloat("BackgroundVolume", volume);
    }
    public void SetEffect()
    {
        float volume = EffectSlider.value;
        audioMixer.SetFloat("Effect", Mathf.Log10(volume) * 20);
        EffectValue.text = (volume * 100).ToString("F0");
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }
    //public void SetCharacter()
    //{
    //    float volume = CharacterSlider.value;
    //    audioMixer.SetFloat("Character", Mathf.Log10(volume) * 20);
    //    CharacterValue.text = (volume * 100).ToString("F0");
    //    PlayerPrefs.SetFloat("CharacterVolume", volume);
    //}
    public void SetVoice()
    {
        float volume = VoiceSlider.value;
        audioMixer.SetFloat("Voice", Mathf.Log10(volume) * 20);
        VoiceValue.text = (volume * 100).ToString("F0");
        PlayerPrefs.SetFloat("VoiceVolume", volume);
    }
    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        BackgroundSlider.value = PlayerPrefs.GetFloat("BackgroundVolume");
        EffectSlider.value = PlayerPrefs.GetFloat("EffectVolume");
        //CharacterSlider.value = PlayerPrefs.GetFloat("CharacterVolume");
        VoiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume");
        SetMaster();
        SetBackground();
        SetEffect();
        //SetCharacter();
        SetVoice();
    }
}
