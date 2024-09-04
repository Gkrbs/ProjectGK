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
        // 퀘스트 이니셜라이즈
        QuestManager.instance.InstallQuest();
        // 이상현상 이니셜라이즈
        AbnormalyManager.instance.AbnomalyInstall();
    }
    //침대에 상호작용시 작동
    public void GoToNextDate()
    {
        Debug.Log("다음날" + DATE);
        if (isCompleteAllMission())
        {
            date += 1;
            switch (date)
            {
                case int n when (n < TURNOFF_DATE):
                    ChangeDay(DAY.DAY);
                    // 퀘스트 초기화후 고르기
                    QuestManager.instance.InstallQuest();
                    break;
                case int n when (n < CLEAR_DATE):
                    ChangeDay(DAY.NIGHT);
                    // 퀘스트 초기화후 고르기
                    QuestManager.instance.InstallQuest();
                    // 이상현상 초기화후 고르기
                    AbnormalyManager.instance.AbnomalyInstall();
                    break;
                case CLEAR_DATE:
                    ChangeDay(DAY.DAY);
                    // 퀘스트 없음
                    // 이상현상 없음
                    // 버스 출발
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
        Debug.Log("전화");
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
        Debug.Log("버스 탐");
        if(isGameClear)
            StartCoroutine(Ending());
    }
    IEnumerator Ending()
    {
        bl_SceneLoaderManager.LoadScene(endingSceneName);
        yield return null;
    }


}
