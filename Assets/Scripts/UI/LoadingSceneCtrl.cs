using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneCtrl : MonoBehaviour
{
    private static string nextScene;
    [SerializeField]private Image progressBar;
    public static void LoadScene(string sceneName){
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private void Start() {
        StartCoroutine(LoadSceneProgress());
    }

    IEnumerator LoadSceneProgress(){
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        
        float timer = 0;
        while(!op.isDone){
            yield return null;

            if(op.progress < 0.9f){
                progressBar.fillAmount = op.progress;
            }
            else{
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer*0.5f);
                if(progressBar.fillAmount >= 1f){
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
