using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    public static LoadSceneManager instance;
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }
    //public int CurrentSceneIndex()
    //{
    //    return SceneManager.GetActiveScene().buildIndex;
    //}
    public void LoadScene(int buildIndex)
    {
        StartCoroutine(LoadYourAsyncScene(buildIndex));
    }
    IEnumerator LoadYourAsyncScene(int buildIndex)
    {
        //GameManager.instance.Initialize();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(buildIndex);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
