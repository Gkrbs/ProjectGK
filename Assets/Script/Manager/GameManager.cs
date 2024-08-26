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

    // ħ�� ��ȣ�ۿ�� �������� �ѱ������ üũ�ϱ�
    // ���н� �ʱ�ȭ �ϱ�
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
        // ����Ʈ �̴ϼȶ�����
        QuestManager.instance.InstallQuest();
        // �̻����� �̴ϼȶ�����
    }
    //ħ�뿡 ��ȣ�ۿ�� �۵�
    public void GoToNextDate()
    {
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
                    //AbnormalManager.instance.AnomalyInstall();
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

    }
    public void CallAbnormal()
    {
        isCall = true;
        // �̻������� ������ ����
        // �̻������� ������ ����
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
                    // �̻����� ������
                    // ��ȭ�ɸ�
                    if (isCall)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (isCall)
                        return false;
                    // �̻����� ������
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
