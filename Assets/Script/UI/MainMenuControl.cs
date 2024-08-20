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
        //씬로드 애니메이션 나오게
        settingTabsControl.GoToLobbyButton.SetActive(true);
        LoadSceneManager.instance.LoadScene(Scenes.play);
    }
    public void SettingButton()
    {
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
