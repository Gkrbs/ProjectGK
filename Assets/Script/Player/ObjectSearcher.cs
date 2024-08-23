using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSearcher : MonoBehaviour
{
    [SerializeField]
    private float radius = 2.5f;
    [SerializeField]
    private float iconPosTemp = 1.0f;
    [SerializeField]
    private float viewRangeX = 0.15f;
    [SerializeField]
    private float viewRangeY = 0.30f;
    [SerializeField]
    private LayerMask mask;
    private Camera cam;
    private GameObject searchItem;
    [SerializeField]
    private GameObject interactionIcon;

    public GameObject item => searchItem;
    private void Start()
    {
        cam = Camera.main;
    }
    private void OnTriggerStay(Collider other)
    {
        Search(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (searchItem == other.gameObject)
        {
            searchItem = null;
            if (interactionIcon.activeSelf)
                interactionIcon.SetActive(false);
        }
    }

    private void Search(GameObject item)
    {
        GameObject value = searchItem;
        Vector3 newViewPos = cam.WorldToViewportPoint(item.transform.position);
        float newDef = Mathf.Abs(0.5f - Mathf.Abs(newViewPos.x));

        if (value != null)
        {
            Vector3 ViewPos = cam.WorldToViewportPoint(value.transform.position);
            float def = Mathf.Abs(0.5f - Mathf.Abs(ViewPos.x));

            if (def > newDef)
                value = item;
        }
        else
        {
            value = item;
        }

        Vector3 viewPos = cam.WorldToViewportPoint(value.transform.position);

        if (viewPos.x >= 0.5f - viewRangeX && viewPos.x <= 0.5f + viewRangeX
            && viewPos.y >= 0.5f - viewRangeY && viewPos.y <= 0.5f + viewRangeY
            && viewPos.z > 0f)
        {
            searchItem = value;
            interactionIcon.SetActive(true);
        }
        else
        {
            searchItem = null;
            interactionIcon.SetActive(false);
        }

    }
    private void ClearDisableSearchObject()
    {
        if (searchItem == null) return;
        if (searchItem.activeSelf) return;

        searchItem = null;

        if (interactionIcon.activeSelf)
            interactionIcon.SetActive(false);
    }
    private void Update()
    {
        ClearDisableSearchObject();
    }
    //private void Search()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position,radius,mask);
    //    GameObject searchObject = null;

    //    foreach (Collider col in colliders)
    //    {
    //        if (searchObject == null)
    //        {
    //            searchObject = col.gameObject;
    //        }
    //        else
    //        {
    //            float currentLength = Vector3.Distance(transform.position, searchObject.transform.position);
    //            float nextLength = Vector3.Distance(transform.position, col.gameObject.transform.position);
    //            if (currentLength > nextLength)
    //            {
    //                searchObject = col.gameObject;
    //            }
    //        }
    //    }
    //    searchItem = searchObject;
    //}
}
