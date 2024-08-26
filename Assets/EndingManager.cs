using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public bool byName = true;
    public string sceneName;
    public int sceneID = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            LoadScene();
        }
    }
    public void LoadScene()
    {
        if (Time.timeScale != 1.0f)
            Time.timeScale = 1.0f;

        if (byName)
        {
            if (string.IsNullOrEmpty(sceneName)) return;
            bl_SceneLoaderManager.LoadScene(sceneName);
        }
        else
        {
            bl_SceneLoaderManager.LoadSceneByID(sceneID);
        }
    }
}
