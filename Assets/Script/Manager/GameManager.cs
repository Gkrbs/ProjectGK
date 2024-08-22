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
    private const int INIT_DATE = 0;
    private const int TIME_TURNOFF = 4;
    private const int CLEAR_DATE = 13;
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
    public GameObject CommuterBus;

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
    void SetAcitveBus(bool active)
    {
        CommuterBus.SetActive(active);
    }
    //ħ�뿡 ��ȣ�ۿ�� �۵�
    public void GoToNextDate()
    {
        if (isCompleteAllMission())
        {
            date += 1;
            switch (date)
            {
                case int n when (n < TIME_TURNOFF):
                    currentDay = DAY.DAY;
                    // ����Ʈ �ʱ�ȭ�� ����
                    break;
                case int n when (n < CLEAR_DATE):
                    currentDay = DAY.NIGHT;
                    // ����Ʈ �ʱ�ȭ�� ����
                    // �̻����� �ʱ�ȭ�� ����
                    break;
                case CLEAR_DATE:
                    currentDay = DAY.DAY;
                    // ����Ʈ ����
                    // �̻����� ����
                    // ���� ���
                    SetAcitveBus(true);
                    isGameClear = true;
                    break;
            }
        }
        else
        {
            MissionFailed();
        }

    }
    public bool isCompleteAllMission()
    {
        switch (date)
        {
            case int n when (n < TIME_TURNOFF):
                if (QuestManager.instance.IS_CLEAR)
                    return true;
                break;
            case int n when (n < CLEAR_DATE):
                if (isAnormal)
                {
                    // �̻����� ������
                    // ��ȭ�ɸ�
                    return true;
                }
                else
                {
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
        if (date < TIME_TURNOFF)
        {
            date = INIT_DATE;
            currentDay = DAY.DAY;
        }
        else if (date < CLEAR_DATE)
        {
            date = TIME_TURNOFF;
            currentDay = DAY.NIGHT;
        }
    }
    public void Initialize()
    {
        isGameClear = false;
        date = INIT_DATE;
        currentDay = DAY.DAY;
        // ����Ʈ �̴ϼȶ�����
        // �̻����� �̴ϼȶ�����
    }
}
