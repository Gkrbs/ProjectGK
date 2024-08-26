using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : Item
{
    //퀘스트 아이템 상호작용 시 발생되는 이벤트 클리어 카운트를 증가시킴

    public override void Interaction()
    {
        base.Interaction();
        gameObject.SetActive(false);
    }

    public override void Init(string itemId)
    {
        base.Init(itemId);
    }
}
