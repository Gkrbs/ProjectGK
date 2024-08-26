using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abnormaly : MonoBehaviour, AbnormalInterface
{
    public bool isClear = false;
    public bool playAbnormal = false;

    protected GameObject[] abnormalObjects;
    
    protected delegate void PlayDelegate();
    protected event PlayDelegate PlayEvent;
    protected event PlayDelegate ResetEvent;

    public virtual void Init(string id ="")
    {
        foreach (GameObject item in abnormalObjects)
        {
            AbnormalyItem aItem = item.GetComponent<AbnormalyItem>();
            PlayEvent += aItem.PlayEvent;
            ResetEvent += aItem.ResetEvent;
        }
    }

    public virtual void ReInit()
    {
        playAbnormal = true;
    }

    public virtual void Trigger(GameObject other)
    {
        if (!playAbnormal) return;

        if (PlayEvent != null)
            PlayEvent();
    }

    public virtual void ReSet()
    {
        if (!playAbnormal) return;

        if (ResetEvent != null)
            ResetEvent();
        playAbnormal = false;
    }
}
