using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelCtrl : MonoBehaviour
{
    private int maxExpToLevelUp = 10;
    private int exp = 0;
    [SerializeField]private TextMeshProUGUI levelText;
    [SerializeField]private Slider expBar;
    void Start()
    {
        GameManager.Instance.playerLevel = 1;
        levelText.text = GameManager.Instance.playerLevel.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("EXP")){
            other.gameObject.SetActive(false);
            GetExp();
        }
    }

    private void GetExp(){
        exp++;
        if(exp>=maxExpToLevelUp){
            LevelUp();
        }
        Debug.Log("a");
        expBar.value = exp / (float)maxExpToLevelUp;
    }

    private void LevelUp(){
        exp = 0;
        GameManager.Instance.playerLevel++;
        maxExpToLevelUp = (int)(maxExpToLevelUp * 1.5f);
        levelText.text = GameManager.Instance.playerLevel.ToString();
    }
}
