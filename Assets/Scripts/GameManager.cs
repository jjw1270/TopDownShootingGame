using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject Player;
    public int playtimeSec = 0;
    [SerializeField]TextMeshProUGUI timerText;

    private void Start() {
        InvokeRepeating("Timer", 1f, 1f);

        //CancelInvoke("Timer");
    }

    private void Update() {

    }

    void Timer(){
        playtimeSec += 1;
        timerText.text = string.Format("{0:D2} : {1:D2}", playtimeSec / 60, playtimeSec % 60);
    }
}
