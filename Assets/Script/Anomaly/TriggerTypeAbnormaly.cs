using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTypeAbnormaly : Abnormaly
{
    private enum TRIGGER_TYPE
    {
        ENTER,
        STAY,
        EXIT
    }

    [SerializeField]
    TRIGGER_TYPE type;

    [SerializeField]
    private Trigger trigger;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init(string id = "")
    {
        switch (type)
        {
            case TRIGGER_TYPE.ENTER:
                trigger.TriggerEnter += Trigger;
                break;
            case TRIGGER_TYPE.STAY:
                trigger.TriggerStay += Trigger;
                break;
            case TRIGGER_TYPE.EXIT:
                trigger.TriggerExit += Trigger;
                break;
        }
        base.Init(id);

    }

    public override void Trigger(GameObject other)
    {
        base.Trigger(other);
    }
}
