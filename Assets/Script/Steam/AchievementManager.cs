using Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    /*
    ���� ����               0
    �븻 ����               1
    ���� Ŭ����             2
    �븻 Ŭ����             3
    Ÿ�Ӿ���                4
    �׷��ø������� 121��    5
    ������ �ִ� �ð�        6
    3�����̷�               7
    2����������             8
    ���� Ƚ��
    �׷��� Ƚ��
    ��Ʈ�� ��� Ƚ��
    ���� ��� Ƚ��
    ���� ���� Ƚ��
    Ŭ����Ƚ��
    ���̺�Ƚ��
    �ε�Ƚ��
     */
    public enum IDS
    {
        ENTER_GAME,
        TIME_ATTACK,
        TOTAL_ABNORMAL_COUNT,
        TOTAL_QUEST_COUNT,
        TOTAL_CLEAR_COUNT,
        TOTAL_START_COUNT
    }
    public string[] arc_id;
    public string[] stat_id;
    public bool isThisAchievementUnlocked(int id)
    {
        if (!SteamManager.instance.IS_INIT)
            return false;
        var ach = new Steamworks.Data.Achievement(arc_id[id]);
        return ach.State;
    }
    public bool AchievementCount(int id)
    {
        if (!SteamManager.instance.IS_INIT)
            return false;
        int current_cnt = SteamUserStats.GetStatInt(stat_id[id]) + 1;
        bool res = SteamUserStats.SetStat(stat_id[id], current_cnt);
        SteamUserStats.StoreStats();
        return res;
    }
    public void UnlockedAchievement(int id)
    {
        if (!SteamManager.instance.IS_INIT)
            return;
        var ach = new Steamworks.Data.Achievement(arc_id[id]);
        ach.Trigger();
    }

    public void ClearAchievementStatus(int id)
    {
        if (!SteamManager.instance.IS_INIT)
            return;
        var ach = new Steamworks.Data.Achievement(arc_id[id]);
        ach.Clear();
    }

    public bool isThisAchievementUnlocked(string id)
    {
        if (!SteamManager.instance.IS_INIT)
            return false;
        var ach = new Steamworks.Data.Achievement(id);
        return ach.State;
    }
    public bool AchievementCount(string id)
    {
        if (!SteamManager.instance.IS_INIT)
            return false;
        int current_cnt = SteamUserStats.GetStatInt(id) + 1;
        bool res = SteamUserStats.SetStat(id, current_cnt);
        SteamUserStats.StoreStats();
        return res;
    }
    public void UnlockedAchievement(string id)
    {
        if (!SteamManager.instance.IS_INIT)
            return;
        var ach = new Steamworks.Data.Achievement(id);
        ach.Trigger();
    }

    public void ClearAchievementStatus(string id)
    {
        if (!SteamManager.instance.IS_INIT)
            return;
        var ach = new Steamworks.Data.Achievement(id);
        ach.Clear();
    }
}
