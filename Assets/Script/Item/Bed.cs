using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Item
{
    public override void Init(string itemId = "")
    {
        base.Init(itemId);
        if (GameManager.instance != null)
            InteractionEvent += GameManager.instance.GoToNextDate;
    }

    public override void Interaction()
    {
        //GameManager�� �̻����� �߰��� �˸��� �ڵ� ����
        base.Interaction();
    }
    private void Start()
    {
        Init();
    }
}
