using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIControl : MonoBehaviour
{
    public GameObject blackoutPanel;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(BlackOutSetFalse());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BlackOutSetFalse()
    {
        yield return new WaitForSeconds(2);
        blackoutPanel.SetActive(false);
    }
}
