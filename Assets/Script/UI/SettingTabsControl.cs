using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class SettingTabsControl : MonoBehaviour
{
    enum TABS
    {
        GRAPHIC,
        AUDIO,
        CONTROL,
        GAME
    }
    public GameObject Option;
    public List<GameObject> Panels = new();
    public GameObject GoToLobbyCheckPanel;
    public GameObject GoToLobbyButton;
    private void Start()
    {
        if (Panels.Count <= 0) return;
        //foreach (GameObject tab in Panels)
        //{
        //    tab.SetActive(false);
        //}
        OpenPanel((int)TABS.GRAPHIC);
        Option.SetActive(false);
        //Panels[(int)TABS.GRAPHIC].SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == Scenes.play)
        {
            OptionControl();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
    public void OpenPanel(int num)
    {
        if (Panels.Count <= 0) return;
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(false);
        }
        Panels[num].SetActive(true);
    }
    public void OptionControl()
    {
        if (Option == null) return;
        GameManager.instance.isSettingOpen = !GameManager.instance.isSettingOpen;
        GameManager.instance.UIOnOff();
        if (GameManager.instance.isSettingOpen)
        {
            Option.SetActive(GameManager.instance.isSettingOpen);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            OpenPanel((int)TABS.GRAPHIC);
        }
        else
        {
            Option.SetActive(GameManager.instance.isSettingOpen);
            if (SceneManager.GetActiveScene().buildIndex == Scenes.play)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ExitButton()
    {
        GoToLobbyCheckPanel.SetActive(true);
        Debug.Log("씬전환 확인메세지 띄우기");
    }
    public void CancelExit()
    {
        GoToLobbyCheckPanel.SetActive(false);
    }
    public void AcceptLobbyButton()
    {
        GoToLobbyButton.SetActive(false);
        GoToLobbyCheckPanel.SetActive(false);
        OptionControl();
        //LoadSceneManager.instance.LoadScene(0);
    }
}
