using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]private Animator anim;
    public void GameStart(){
        SoundManager.Instance.PlaySFXSound("Spell_00");
        anim.SetBool("isGameStart", true);
        Invoke("LoadMainScene", 1f);
        
    }
    private void LoadMainScene(){
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame(){
        SoundManager.Instance.PlaySFXSound("Menu_Select_00");
        Application.Quit();
#if !UNITY_EDITOR
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
    }
}
