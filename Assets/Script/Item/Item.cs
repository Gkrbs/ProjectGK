using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, InteractionItemInterface
{
    public string itemId = "";

    public delegate void InteractionDelegate();
    public event InteractionDelegate InteractionEvent;

    public virtual void Init(string itemId = "")
    {
        this.itemId = itemId;
    }

    public virtual void Interaction()
    {
        if (InteractionEvent != null)
            InteractionEvent();
    }
}
