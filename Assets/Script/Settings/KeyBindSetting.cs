using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using TMPro;
public class KeyBindSetting : MonoBehaviour
{
    // 게임 내에서 쓰는 실제 키바인드 객체
    public KeyBind keyBind = new KeyBind();

    public GameObject KeyBindCheckPanel;
    public GameObject resetCheckPanel;
    public List<TMP_Text> keyTexts = new();

    int key = -1;
    GameObject currentObj = null;
    bool changing = false;
    private void Start()
    {
        if (PlayerPrefs.HasKey(InputCode.KEY_UP.ToString()))
        {
            keyBind.Load();
        }
        else
        {
            keyBind.ResetAll();
        }
        KeyBindCheckPanel.SetActive(false);
        ResetCheckPanelActive(false);
        UpdateKeyText();
    }
    public void OpenCheckPanel()
    {
        KeyBindCheckPanel.SetActive(true);
        changing = true;
    }
    void CloseCheckPanel()
    {
        key = -1;
        currentObj = null;
        changing = false;
        KeyBindCheckPanel.SetActive(false);
    }
    void CheckAvailable()
    {
        // w a s d esc enter 키는 안되게
    }
    private void OnGUI()
    {
        if (!changing || Event.current.type == EventType.MouseUp) return;

        switch (Event.current.type)
        {
            case EventType.KeyDown:
                Event keyEvent = Event.current;
                if (keyEvent.keyCode == KeyCode.Escape)
                {
                    CloseCheckPanel();
                    return;
                }
                keyBind.Bind((InputCode)key, keyEvent.keyCode);
                UpdateKeyText();
                CloseCheckPanel();
                break;
            case EventType.MouseDown:
                int num = Event.current.button;
                KeyCode input = (KeyCode)Enum.Parse(typeof(KeyCode), "Mouse" + num);
                keyBind.Bind((InputCode)key, input);
                UpdateKeyText();
                CloseCheckPanel();
                break;
            //case EventType.ScrollWheel:
            //    if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            //    {
            //        Input.mouseScrollDelta
            //    }
            //    UpdateKeyText();
            //    CloseCheckPanel();
            //    break;
            default:
                break;
        }



    }
    public void KeyChange()
    {
        currentObj = EventSystem.current.currentSelectedGameObject;
        key = (int)Enum.Parse(typeof(InputCode), currentObj.name);
        OpenCheckPanel();
    }
    public void ResetButton()
    {
        ResetCheckPanelActive(true);
    }
    public void ResetCheckPanelActive(bool check)
    {
        if (resetCheckPanel == null) return;
        resetCheckPanel.SetActive(check);
    }
    public void KeyReset()
    {
        keyBind.ResetAll();
        UpdateKeyText();
    }
    public void UpdateKeyText()
    {
        for (int i = 0; i < keyTexts.Count; i++)
        {
            string temp = KeyBind.dictBinds[(InputCode)i].ToString();
            keyTexts[i].text = temp;// == "None" ? "" : temp;
        }
    }
}
