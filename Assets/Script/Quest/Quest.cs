using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    private bool isInit = false;
    private bool isClear = false;
    private int clearCount = 0;
    private int maxClearCount = 0;
    private string questId = "";
    private string name = "";
    private string info = "";
    [SerializeField]
    private string questItemPath = "Prefabs\\Quest\\QuestItem";
    [SerializeField]
    private QuestData data;

    public QuestItem[] questItems;
    
    public delegate void SetUIDelegate(string name, string info, int cnt, int maxCnt, bool isClear);
    public event SetUIDelegate SetUIEvent;
    public bool IS_CLEAR => isClear;

    public void Init()
    {
        if (isInit) return;

        if (data == null)
        {
            isInit = false;
            return;
        }

        isClear = false;
        clearCount = 0;
        maxClearCount = data.clearCount;
        name = data.name;
        info = data.info;
        questId = data.questId;
        questItems = new QuestItem[maxClearCount];

        foreach(QuestItem item in questItems)
        {
            item.InteractionEvent += AddClearCount;
            item.gameObject.SetActive(false);
        }

        //for (int i = 0; i < questItems.Length; i++)
        //{
        //    QuestItem item = Resources.Load<QuestItem>(questItemPath);

        //    questItems[i] = Instantiate<QuestItem>(item, transform);
        //    questItems[i].gameObject.name = "QuestItem" + (i + 1).ToString("D2");

        //    if (questItemPos.Length > 0)
        //    {
        //        if (questItemPos[i] != null)
        //        {
        //            questItems[i].gameObject.transform.position = questItemPos[i].position;
        //            questItems[i].gameObject.transform.rotation = questItemPos[i].rotation;
        //        }
        //    }
        //    questItems[i].InteractionEvent += AddClearCount;
        //    questItems[i].gameObject.SetActive(false);
        //}
        isInit = true;

    }

    public void DisableItem()
    {
        foreach (QuestItem item in questItems)
        {
            item.gameObject.SetActive(false);
        }
    }

    //리이닛 시점은 퀘스트 셋팅되는 시점
    public void ReInit()
    {
        if (!isInit) return;

        isClear = false;
        clearCount = 0;
        foreach (QuestItem item in questItems)
        {
            item.gameObject.SetActive(true);
        }

    }

    public void SetUi()
    {
        if (SetUIEvent != null)
            SetUIEvent(name, info, clearCount, maxClearCount, isClear);
    }

    //이벤트 연동할 예정
    public void AddClearCount()
    {
        if (!isInit) return;

        if (maxClearCount == 0)
        {
            isClear = true;
            return;
        }

        if (clearCount < maxClearCount)
            clearCount++;

        if (clearCount >= maxClearCount)
            isClear = true;

        if (SetUIEvent != null)
            SetUIEvent(name, info, clearCount, maxClearCount, isClear);
    }
    private void Start()
    {
        Init();
    }
}
