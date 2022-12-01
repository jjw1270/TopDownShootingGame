using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject Player;
    public int playtimeSec;
    public int currentEnemyCount;
    public PlayerHPCtrl playerHPCtrl;
    public SkillCtrl skillCtrl;
    public int enemyDeathCount;
    [SerializeField]private TextMeshProUGUI timerText;
    public string Exp = "Exp";
    public int playerLevel = 0;

    private void Start() {
        Init();
        InvokeRepeating("Timer", 1f, 1f);
    }

    private void Init(){
        playtimeSec = 0;
        currentEnemyCount = 0;
        enemyDeathCount = 0;
    }

    private void Update() {

    }

    private void Timer(){
        playtimeSec += 1;
        timerText.text = string.Format("{0:D2} : {1:D2}", playtimeSec / 60, playtimeSec % 60);
    }

    public void GameOver(){
        StopAllCoroutines();
        CancelInvoke("Timer");
        //게임오버 씬
    }
}
