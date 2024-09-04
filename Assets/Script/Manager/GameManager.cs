using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isUIOpen = false;
    public bool isSettingOpen = false;

    public bool isGameClear = false;
    public bool isAnormal = false;
    public bool isCall = false;

    public Image fadeInOutImage;

    private const int INIT_DATE = 0;
    private const int TURNOFF_DATE = 4;
    private const int CLEAR_DATE = 13;

    public Material daySkyBox;
    public Material nightSkyBox;

    public string endingSceneName;
    public enum DAY
    {
        DAY,
        NIGHT
    }
    public DAY currentDay = DAY.DAY;
    private int date = 0;
    public int DATE
    {
        get
        {
            return date;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    public void UIOnOff()
    {
        isUIOpen = isSettingOpen;
    }
    public void Initialize()
    {
        isGameClear = false;
        date = INIT_DATE;
        currentDay = DAY.DAY;
        // ����Ʈ �̴ϼȶ�����
        QuestManager.instance.InstallQuest();
        // �̻����� �̴ϼȶ�����
        AbnormalyManager.instance.AbnomalyInstall();
    }
    //ħ�뿡 ��ȣ�ۿ�� �۵�
    public void GoToNextDate()
    {
        Debug.Log("������" + DATE);
        if (isCompleteAllMission())
        {
            date += 1;
            switch (date)
            {
                case int n when (n < TURNOFF_DATE):
                    ChangeDay(DAY.DAY);
                    // ����Ʈ �ʱ�ȭ�� ����
                    QuestManager.instance.InstallQuest();
                    break;
                case int n when (n < CLEAR_DATE):
                    ChangeDay(DAY.NIGHT);
                    // ����Ʈ �ʱ�ȭ�� ����
                    QuestManager.instance.InstallQuest();
                    // �̻����� �ʱ�ȭ�� ����
                    AbnormalyManager.instance.AbnomalyInstall();
                    break;
                case CLEAR_DATE:
                    ChangeDay(DAY.DAY);
                    // ����Ʈ ����
                    // �̻����� ����
                    // ���� ���
                    isGameClear = true;
                    break;
            }
        }
        else
        {
            MissionFailed();
        }
        isCall = false;
    }
    public void CallAbnormal()
    {
        Debug.Log("��ȭ");
        isCall = true;
        AbnormalyManager.instance.ClearAnormaly();
    }
    public bool isCompleteAllMission()
    {
        switch (date)
        {
            case int n when (n < TURNOFF_DATE):
                if (QuestManager.instance.IS_CLEAR)
                    return true;
                break;
            case int n when (n < CLEAR_DATE):
                if (AbnormalyManager.instance.isEnabled)
                {
                    if (isCall)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (isCall)
                        return false;
                    if (QuestManager.instance.IS_CLEAR)
                        return true;
                }
                break;
            case CLEAR_DATE:
                return true;
        }
        return false;
    }
    public void MissionFailed()
    {
        isGameClear = false;
        if (date < TURNOFF_DATE)
        {
            date = INIT_DATE;
            ChangeDay(DAY.DAY);
        }
        else if (date < CLEAR_DATE)
        {
            date = TURNOFF_DATE;
            AbnormalyManager.instance.AnomalyListReset();
            ChangeDay(DAY.NIGHT);
        }
    }
    public void ChangeDay(DAY day)
    {
        if (currentDay == day)
            return;
        currentDay = day;
        switch (currentDay)
        {
            case DAY.DAY:
                if (daySkyBox == null)
                    return;
                RenderSettings.skybox = daySkyBox;
                break;
            case DAY.NIGHT:
                if (nightSkyBox == null)
                    return;
                RenderSettings.skybox = nightSkyBox;
                break;
        }
    }
    public void GetOnBus()
    {
        Debug.Log("���� Ž");
        if(isGameClear)
            StartCoroutine(Ending());
    }
    IEnumerator Ending()
    {
        bl_SceneLoaderManager.LoadScene(endingSceneName);
        yield return null;
    }


}
