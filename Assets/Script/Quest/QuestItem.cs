using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : Item
{
    //����Ʈ ������ ��ȣ�ۿ� �� �߻��Ǵ� �̺�Ʈ Ŭ���� ī��Ʈ�� ������Ŵ

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
