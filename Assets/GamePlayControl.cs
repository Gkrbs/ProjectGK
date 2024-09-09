using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
public class GamePlayControl : MonoBehaviour
{
    
    public SelectUI LanguageSetting;
    void Start()
    {
        if (PlayerPrefs.HasKey("Language"))
        {
            LoadValue();
        }
        else
        {
            SetDefault();
        }
    }
    public void SetDefault()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        PlayerPrefs.SetInt("Language", LanguageSetting.currentIndex);
    }

    public void SetLanguage()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[LanguageSetting.currentIndex];
        PlayerPrefs.SetInt("Language", LanguageSetting.currentIndex);
    }
    private void LoadValue()
    {
        LanguageSetting.CustomSet(PlayerPrefs.GetInt("Language"));
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefs.GetInt("Language")];

    }

}
