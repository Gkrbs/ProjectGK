using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abnormaly : MonoBehaviour, AbnormalInterface
{
    public bool isClear = false;
    public bool playAbnormal = false;

    [SerializeField]
    protected GameObject[] abnormalObjects;
    
    protected delegate void PlayDelegate(GameObject target);
    protected delegate void ResetDelegate();
    protected event PlayDelegate PlayEvent;
    protected event ResetDelegate ResetEvent;

    public virtual void Init(string id ="")
    {
        foreach (GameObject item in abnormalObjects)
        {
            AbnormalyItem aItem = item.GetComponent<AbnormalyItem>();
            PlayEvent += aItem.PlayEvent;
            ResetEvent += aItem.ResetEvent;
            item.SetActive(false);
        }
    }

    public virtual void ReInit()
    {
        playAbnormal = true;
        foreach (GameObject item in abnormalObjects)
        {
            item.SetActive(true);
        }
    }

    public virtual void Trigger(GameObject other)
    {
        if (!playAbnormal) return;

        if (PlayEvent != null)
            PlayEvent(other);
    }

    public virtual void ReSet()
    {
        if (!playAbnormal) return;

        if (ResetEvent != null)
            ResetEvent();

        foreach (GameObject item in abnormalObjects)
        {
            item.SetActive(false);
        }
        playAbnormal = false;
    }
}
