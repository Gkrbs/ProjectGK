using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour, InteractionItemInterface
{
    public string QuestId = "";
    //����Ʈ ������ ��ȣ�ۿ� �� �߻��Ǵ� �̺�Ʈ Ŭ���� ī��Ʈ�� ������Ŵ
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
