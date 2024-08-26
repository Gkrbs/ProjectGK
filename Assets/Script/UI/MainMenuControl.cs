using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{
    [SerializeField] SettingTabsControl settingTabsControl;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject exitGameCheckPanel;
    
    private void Start()
    {
        if (settingPanel == null)
            settingPanel = GameObject.Find("SettingPanel");
        if (settingTabsControl == null)
            settingTabsControl = GameObject.Find("SettingManager").GetComponent<SettingTabsControl>();
    }
    private void Update()
    {
        if (settingPanel == null)
            settingPanel = GameObject.Find("SettingPanel");
        if (settingTabsControl == null)
            settingTabsControl = GameObject.Find("SettingManager").GetComponent<SettingTabsControl>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingPanel.activeSelf)
                settingPanel.SetActive(false);
            else if (exitGameCheckPanel.activeSelf)
                exitGameCheckPanel.SetActive(false);
            else
                ExitGameCheck();
        }
    }
    public void StartButton()
    {
        if (settingTabsControl == null)
            settingTabsControl = GameObject.Find("SettingManager").GetComponent<SettingTabsControl>();
        //���ε� �ִϸ��̼� ������
        settingTabsControl.GoToLobbyButton.SetActive(true);
        //LoadSceneManager.instance.LoadScene(Scenes.play);
    }
    public void SettingButton()
    {
        if (settingTabsControl == null)
            settingTabsControl = GameObject.Find("SettingManager").GetComponent<SettingTabsControl>();
        settingTabsControl.OptionControl();
    }
    public void ExitButton()
    {
        ExitGameCheck();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CancelExitGame()
    {
        exitGameCheckPanel.SetActive(false);
    }
    void ExitGameCheck()
    {
        exitGameCheckPanel.SetActive(true);
    }

}
