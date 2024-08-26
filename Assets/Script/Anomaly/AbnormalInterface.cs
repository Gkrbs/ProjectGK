using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AbnormalInterface
{
    public void Init(string id);
    public void Trigger(GameObject other);
    public void ReSet();
}
