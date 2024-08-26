using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isUIOpen = false;
    public bool isSettingOpen = false;

    public bool isGameClear = false;
    public bool isAnormal = false;
    public bool isCall = false;
    private const int INIT_DATE = 0;
    private const int TURNOFF_DATE = 4;
    private const int CLEAR_DATE = 13;

    public Material daySkyBox;
    public Material nightSkyBox;

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

    // Start is called before the first frame update
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

    // 침대 상호작용시 다음날로 넘길것인지 체크하기
    // 실패시 초기화 하기
    //
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
    }
    //침대에 상호작용시 작동
    public void GoToNextDate()
    {
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
                    //AbnormalManager.instance.AnomalyInstall();
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

    }
    public void CallAbnormal()
    {
        isCall = true;
        // 이상현상이 있으면 성공
        // 이상현상이 없으면 실패
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
                if (isAnormal)
                {
                    // 이상현상 있을때
                    // 전화걸면
                    if (isCall)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (isCall)
                        return false;
                    // 이상현상 없을때
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
            currentDay = DAY.DAY;
        }
        else if (date < CLEAR_DATE)
        {
            date = TURNOFF_DATE;
            currentDay = DAY.NIGHT;
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
                if (daySkyBox == null )
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
}
