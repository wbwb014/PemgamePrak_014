using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;
    public Text loadingText;
    public static bool loadStatus;

    public void loadlevel(int sceneIndex){
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = false;
        // Debug.Log("Loaded");
    }

    public void LoadSaveGame(int sceneIndex){
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
        loadStatus = true;
        
    }

    IEnumerator LoadAsync(int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone){
            int progress = (int)Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.value = progress;
            loadingText.text = progress * 100 + "%";

            yield return null;
        }
    }
}
