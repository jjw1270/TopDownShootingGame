using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPanelCtrl : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI gameOverText;
    [SerializeField]private TextMeshProUGUI enemyKillCountText;
    [SerializeField]private TextMeshProUGUI survivalTimeText;
    
    private void OnEnable() {
        Time.timeScale = 0;
        if(GameManager.Instance.isFail){
            gameOverText.text = "Game Over";
            SoundManager.Instance.PlaySFXSound("Jingle_Lose_00");
        }
        else{
            gameOverText.text = "Congratulations";
            SoundManager.Instance.PlaySFXSound("Jingle_Win_00");
        }
        enemyKillCountText.text = GameManager.Instance.enemyDeathCount.ToString();
        survivalTimeText.text = string.Format("{0:D2} : {1:D2}", GameManager.Instance.playtimeSec / 60, GameManager.Instance.playtimeSec % 60);
    }

    public void GotoLobby(){
        SoundManager.Instance.PlaySFXSound("Spell_00");
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
    }

    public void QuitGame(){
        SoundManager.Instance.PlaySFXSound("Menu_Select_00");
        Application.Quit();
#if !UNITY_EDITOR
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
    }
}
