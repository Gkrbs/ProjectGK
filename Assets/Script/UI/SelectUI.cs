using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelectUI : MonoBehaviour
{
    public Transform selectedBarTr;
    public Transform selectedTextsTr;
    public int currentIndex = 0;
    List<TMP_Text> selectedTexts = new();
    List<Image> selectedBar = new();

    void Awake()
    {
        for (int i = 0; i < selectedTextsTr.childCount; i++)
        {
            selectedTexts.Add(selectedTextsTr.GetChild(i).GetComponent<TMP_Text>());
            selectedBar.Add(selectedBarTr.GetChild(i).GetChild(0).GetComponent<Image>());
        }

        if (PlayerPrefs.HasKey("SelectUIIndex" + gameObject.name))
        {
            LoadData();
        }
        else
        {
            SaveData();
        }
    }

    public void LeftButtonClick()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = 0;
            return;
        }
        for (int i = 0; i < selectedTexts.Count; i++)
        {
            selectedTexts[i].gameObject.SetActive(false);
            selectedBar[i].gameObject.SetActive(false);
        }
        selectedTexts[currentIndex].gameObject.SetActive(true);
        selectedBar[currentIndex].gameObject.SetActive(true);
        SaveData();
    }
    public void RightButtonClick()
    {
        currentIndex++;
        if (currentIndex > selectedTexts.Count - 1)
        {
            currentIndex = selectedTexts.Count - 1;
            return;
        }
        for (int i = 0; i < selectedTexts.Count; i++)
        {
            selectedTexts[i].gameObject.SetActive(false);
            selectedBar[i].gameObject.SetActive(false);
        }
        selectedTexts[currentIndex].gameObject.SetActive(true);
        selectedBar[currentIndex].gameObject.SetActive(true);
        SaveData();
    }
    public void CustomSet(int setInt)
    {
        int index = setInt;
        if (selectedTexts.Count == 0) return;
        if (index < 0) index = 0;
        if (index > selectedTexts.Count - 1) index = selectedTexts.Count - 1;
        currentIndex = index;
        for (int i = 0; i < selectedTexts.Count; i++)
        {
            selectedTexts[i].gameObject.SetActive(false);
            selectedBar[i].gameObject.SetActive(false);
        }
        selectedTexts[currentIndex].gameObject.SetActive(true);
        selectedBar[currentIndex].gameObject.SetActive(true);
        SaveData();
    }
    void SaveData()
    {
        PlayerPrefs.SetInt("SelectUIIndex" + gameObject.name, currentIndex);
    }
    void LoadData()
    {
        currentIndex = PlayerPrefs.GetInt("SelectUIIndex" + gameObject.name);
        for (int i = 0; i < selectedTexts.Count; i++)
        {
            selectedTexts[i].gameObject.SetActive(false);
            selectedBar[i].gameObject.SetActive(false);
        }
        selectedTexts[currentIndex].gameObject.SetActive(true);
        selectedBar[currentIndex].gameObject.SetActive(true);
    }
}
