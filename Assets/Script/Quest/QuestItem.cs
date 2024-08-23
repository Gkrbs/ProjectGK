using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour, InteractionItemInterface
{
    public string QuestId = "";
    //퀘스트 아이템 상호작용 시 발생되는 이벤트 클리어 카운트를 증가시킴
    public delegate void InteractionDelegate();
    public event InteractionDelegate InteractionEvent;

    public void Interaction()
    {
        if (InteractionEvent != null)
            InteractionEvent();

        gameObject.SetActive(false);
    }

    public void Init(string itemId)
    {
        QuestId = itemId;
    }
}
