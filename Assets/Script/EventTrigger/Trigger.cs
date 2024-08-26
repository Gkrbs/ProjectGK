using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public delegate void TriggerDelegate(GameObject other);
    public event TriggerDelegate TriggerEnter;
    public event TriggerDelegate TriggerStay;
    public event TriggerDelegate TriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (TriggerEnter != null)
            TriggerEnter(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (TriggerStay != null)
            TriggerStay(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (TriggerExit != null)
            TriggerExit(other.gameObject);
    }
}
