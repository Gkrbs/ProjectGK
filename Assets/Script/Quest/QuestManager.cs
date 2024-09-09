using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private List<Quest> questList = new List<Quest>();
    private Quest standbyQuest = null;
    private Quest currentQuest = null;

    [SerializeField]
    private TMP_Text questName;
    [SerializeField]
    private TMP_Text questInfo;

    public bool IS_CLEAR
    {
        get
        {
            if (currentQuest == null) return true;

            return currentQuest.IS_CLEAR;
        }
    }

    public void SetQuestUI(string name, string info, int cnt, int maxCnt, bool isClear)
    {
        if (questName != null)
            questName.text = name;

        if (questInfo != null)
        {
            questInfo.text = info;

            if (maxCnt != 0)
                questInfo.text = questInfo.text + " (" + cnt + "/" + maxCnt + ")";

            //퀘스트클리어시 이펙트같은 것을 넣는것도 고려 중
            if (isClear)
                questInfo.color = Color.gray;
            else
                questInfo.color = Color.black;
        }
    }


    public void InstallQuest()
    {
        if (standbyQuest != null)
        {
            questList.Add(standbyQuest);
            standbyQuest = null;
        }

        if (currentQuest != null)
        {
            standbyQuest = currentQuest;
            standbyQuest.DisableItem();
            currentQuest = null;
        }

        if (questList.Count <= 0)
        {
            SetQuestUI("", "", 0, 0, true);
            return;
        }

        int idx = Random.Range(0, questList.Count);
        Quest selectedQuest = questList[idx];
        questList.RemoveAt(idx);
        currentQuest = selectedQuest;
        currentQuest.ReInit();
        currentQuest.SetUi();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<QuestManager>();
        }
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        Quest[] quests = GetComponentsInChildren<Quest>();
        foreach (Quest quest in quests)
        {
            quest.SetUIEvent += SetQuestUI;
            questList.Add(quest);
        }
    }
}
