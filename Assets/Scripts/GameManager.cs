using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject Player;
    public int playtimeSec;
    public PlayerHPCtrl playerHPCtrl;
    public PlayerSkillCtrl playerSkillCtrl;
    public PlayerLevelCtrl playerLevelCtrl;
    [SerializeField]EnemySpawner enemySpawner;
    public int enemyDeathCount;
    [SerializeField]private TextMeshProUGUI timerText;
    public string Exp = "Exp";
    public GameObject damageText;
    [SerializeField]private GameObject gameOverPanel;
    public bool isFail;
    protected override void Awake() {
    }
    private void Start() {
        Init();
        InvokeRepeating("Timer", 1f, 1f);
    }

    private void Init(){
        playtimeSec = 0;
        enemyDeathCount = 0;
    }

    private void Timer(){
        playtimeSec += 1;
        timerText.text = string.Format("{0:D2} : {1:D2}", playtimeSec / 60, playtimeSec % 60);
    }

    public void GameOver(bool _isFail){
        isFail = _isFail;
        enemySpawner.StopAllCoroutines();
        playerSkillCtrl.StopAllCoroutines();
        CancelInvoke("Timer");
        //게임오버 씬
        gameOverPanel.SetActive(true);
    }
}
