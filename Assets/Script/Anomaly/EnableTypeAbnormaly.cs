using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTypeAbnormaly : Abnormaly
{
    //public override void Trigger(GameObject other)
    //{
    //    base.Trigger(other);
    //}

    //public override void Init(string id = "")
    //{
    //    base.Init(id);
    //}

    //public override void ReSet()
    //{
    //    base.ReSet();
    //}
    public override void ReInit()
    {
        base.ReInit();
        Trigger(null);
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
