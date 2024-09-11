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

    protected virtual void ChangeObjectEvent(GameObject target = null)
    {
        if (defaultObj.gameObject.activeSelf)
            defaultObj.gameObject.SetActive(false);
        if (!targetObj.gameObject.activeSelf) 
            targetObj.gameObject.SetActive(true);
    }
    protected virtual void ChangePositionEvent(GameObject target = null)
    {
        defaultObj.transform.Translate(targetPos);
    }
    protected virtual void ChangeRotationEvent(GameObject target = null)
    {
        defaultObj.transform.Rotate(targetRot);
    }
    protected virtual void EnabledObjectEvent(GameObject target = null)
    {
        if (targetObj.gameObject.activeSelf)
            targetObj.gameObject.SetActive(true);
    }

    protected virtual void MoveObjectEvent(GameObject target = null)
    {
        if (!isMove)
        { 
            isMove = true;
            StartCoroutine(MoveObj());
        }
    }

    protected virtual void ChangeObjectEventReset(GameObject target = null)
    {
        if (!defaultObj.gameObject.activeSelf)
            defaultObj.gameObject.SetActive(true);
        if (targetObj.gameObject.activeSelf)
            targetObj.gameObject.SetActive(false);
    }
    protected virtual void ChangePositionEventReset(GameObject target = null)
    {
        defaultObj.transform.Translate(-targetPos);
    }
    protected virtual void ChangeRotationEventReset(GameObject target = null)
    {
        defaultObj.transform.Rotate(-targetRot);
    }
    protected virtual void EnabledObjectEventReset(GameObject target = null)
    {
        if (targetObj.gameObject.activeSelf)
            targetObj.gameObject.SetActive(false);
    }
    protected virtual void MoveObjectEventReset(GameObject target = null)
    {
        defaultObj.transform.Translate(-targetPos);
    }

    public virtual void PlayEvent(GameObject target = null)
    {
        switch (type)
        {
            case ABNORMAL_TYPE.CHANGE_OBJECT:
                ChangeObjectEvent(target);
                break;
            case ABNORMAL_TYPE.CHANGE_POS:
                ChangePositionEvent(target);
                break;
            case ABNORMAL_TYPE.CHANGE_ROTATE:
                ChangeRotationEvent(target);
                break;
            case ABNORMAL_TYPE.ENABLE_OBJECT:
                EnabledObjectEvent(target);
                break;
            case ABNORMAL_TYPE.MOVE_OBJECT:
                MoveObjectEvent(target);
                break;
        }
    }
    public virtual void ResetEvent()
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
    private IEnumerator MoveObj(GameObject target = null)
    {
        Vector3 goalTarget = transform.position + targetPos;
        while (Vector3.Distance(transform.position, targetPos) >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime); 
        }
        transform.position = goalTarget;
        isMove = false;
    }
}
