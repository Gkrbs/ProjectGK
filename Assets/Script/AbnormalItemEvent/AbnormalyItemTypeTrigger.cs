using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalyItemTypeTrigger : AbnormalyItem
{
    private enum TRIGGER_TYPE
    {
        ENTER,
        STAY,
        EXIT
    }

    private TRIGGER_TYPE triggerType;
 
    [SerializeField]
    private Trigger trigger;

    private void Start()
    {
        switch (triggerType)
        {
            case TRIGGER_TYPE.ENTER:
                trigger.TriggerEnter += TriggerPlayEvent;
                break;
            case TRIGGER_TYPE.STAY:
                trigger.TriggerStay += TriggerPlayEvent;
                break;
            case TRIGGER_TYPE.EXIT:
                trigger.TriggerExit += TriggerPlayEvent;
                break;
        }
    }

    private void TriggerPlayEvent(GameObject target)
    {
        base.PlayEvent(target);
    }

    public override void PlayEvent(GameObject target = null)
    {
        trigger.gameObject.SetActive(true);
    }
    public override void ResetEvent()
    {
        base.ResetEvent();
        trigger.gameObject.SetActive(false);
    }
}
