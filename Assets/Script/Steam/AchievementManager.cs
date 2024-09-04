using Steamworks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    /*
    이지 입장               0
    노말 입장               1
    이지 클리어             2
    노말 클리어             3
    타임어택                4
    그래플링연습장 121점    5
    떨어진 최대 시간        6
    3스테이로               7
    2스테이지로             8
    점프 횟수
    그래플 횟수
    제트팩 사용 횟수
    발판 사용 횟수
    음성 나온 횟수
    클리어횟수
    세이브횟수
    로드횟수
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
