using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbnormalyItem : MonoBehaviour
{
    private enum ABNORMAL_TYPE
    {
        CHANGE_POS,
        CHANGE_ROTATE,
        ENABLE_OBJECT,
        CHANGE_OBJECT,
        MOVE_OBJECT
    }
    [SerializeField]
    private ABNORMAL_TYPE type;
    [SerializeField]
    private bool isEnable = true;
    private bool isMove = false;

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private Vector3 targetPos = Vector3.zero;
    [SerializeField]
    private Vector3 targetRot = Vector3.zero;
    [SerializeField]
    private GameObject defaultObj;
    [SerializeField]
    private GameObject targetObj;

    private void Start()
    {
        if (defaultObj == null)
        {
            defaultObj = gameObject;
        }
    }

    private void ChangeObjectEvent()
    {
        if (defaultObj.gameObject.activeSelf)
            defaultObj.gameObject.SetActive(false);
        if (!targetObj.gameObject.activeSelf) 
            targetObj.gameObject.SetActive(true);
    }
    private void ChangePositionEvent()
    {
        defaultObj.transform.Translate(targetPos);
    }
    private void ChangeRotationEvent()
    {
        defaultObj.transform.Rotate(targetRot);
    }
    private void EnabledObjectEvent()
    {
        if (targetObj.gameObject.activeSelf)
            targetObj.gameObject.SetActive(true);
    }

    private void MoveObjectEvent()
    {
        if (!isMove)
        { 
            isMove = true;
            StartCoroutine(MoveObj());
        }
    }

    private void ChangeObjectEventReset()
    {
        if (!defaultObj.gameObject.activeSelf)
            defaultObj.gameObject.SetActive(true);
        if (targetObj.gameObject.activeSelf)
            targetObj.gameObject.SetActive(false);
    }
    private void ChangePositionEventReset()
    {
        defaultObj.transform.Translate(-targetPos);
    }
    private void ChangeRotationEventReset()
    {
        defaultObj.transform.Rotate(-targetRot);
    }
    private void EnabledObjectEventReset()
    {
        if (targetObj.gameObject.activeSelf)
            targetObj.gameObject.SetActive(false);
    }
    private void MoveObjectEventReset()
    {
        defaultObj.transform.Translate(-targetPos);
    }

    public void PlayEvent()
    {
        switch (type)
        {
            case ABNORMAL_TYPE.CHANGE_OBJECT:
                ChangeObjectEvent();
                break;
            case ABNORMAL_TYPE.CHANGE_POS:
                ChangePositionEvent();
                break;
            case ABNORMAL_TYPE.CHANGE_ROTATE:
                ChangeRotationEvent();
                break;
            case ABNORMAL_TYPE.ENABLE_OBJECT:
                EnabledObjectEvent();
                break;
            case ABNORMAL_TYPE.MOVE_OBJECT:
                MoveObjectEvent();
                break;
        }
    }
    public void ResetEvent()
    {
        switch (type)
        {
            case ABNORMAL_TYPE.CHANGE_OBJECT:
                ChangeObjectEventReset();
                break;
            case ABNORMAL_TYPE.CHANGE_POS:
                ChangePositionEventReset();
                break;
            case ABNORMAL_TYPE.CHANGE_ROTATE:
                ChangeRotationEventReset();
                break;
            case ABNORMAL_TYPE.ENABLE_OBJECT:
                EnabledObjectEventReset();
                break;
            case ABNORMAL_TYPE.MOVE_OBJECT:
                MoveObjectEventReset();
                break;
        }
    }
    private IEnumerator MoveObj()
    {
        Vector3 target = transform.position + targetPos;
        while (Vector3.Distance(transform.position, targetPos) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
            yield return Time.deltaTime; 
        }
        transform.position = target;
        isMove = false;
    }
}
