using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerLevelCtrl : MonoBehaviour
{
    private int maxExpToLevelUp = 6;
    private int exp = 0;
    [SerializeField]private TextMeshProUGUI levelText;
    [SerializeField]private Slider expBar;
    public GameObject levelUpPanel;
    [SerializeField]private GameObject[] hudSkillIcons = new GameObject[5];
    [SerializeField]private TextMeshProUGUI[] hudSkillLevels = new TextMeshProUGUI[5];
    public int playerLevel = 0;
    void Start()
    {
        playerLevel = 1;
        levelText.text = playerLevel.ToString();
        PlayerSkillCtrl.skill firstRandomSkill = (PlayerSkillCtrl.skill)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(PlayerSkillCtrl.skill)).Length));
        UpdateSkill(firstRandomSkill);
    }

    public void GetExp(){
        SoundManager.Instance.PlaySFXSound("etfx_spawn");
        exp++;
        if(exp>=maxExpToLevelUp){
            LevelUp();
            exp = 0;
        }
        expBar.value = exp / (float)maxExpToLevelUp;
    }

    private void LevelUp(){
        playerLevel++;
        GameManager.Instance.playerHPCtrl.GetDamage(-30);
        maxExpToLevelUp = playerLevel * 7;
        levelText.text = playerLevel.ToString();

        levelUpPanel.SetActive(true);
    }

    public void UpdateSkill(PlayerSkillCtrl.skill skill){
        GameObject hudSkill = null;
        switch(skill){
            case PlayerSkillCtrl.skill.IceSpear:
                GameManager.Instance.playerSkillCtrl.level_iceSpear++;
                hudSkill = hudSkillIcons[0];
                hudSkillLevels[0].text = GameManager.Instance.playerSkillCtrl.level_iceSpear.ToString();
                break;
            case PlayerSkillCtrl.skill.SparkleBall:
                GameManager.Instance.playerSkillCtrl.level_sparkleBall++;
                hudSkill = hudSkillIcons[1];
                hudSkillLevels[1].text = GameManager.Instance.playerSkillCtrl.level_sparkleBall.ToString();
                break;
            case PlayerSkillCtrl.skill.LightningStrike:
                GameManager.Instance.playerSkillCtrl.level_lightningStrike++;
                hudSkill = hudSkillIcons[2];
                hudSkillLevels[2].text = GameManager.Instance.playerSkillCtrl.level_lightningStrike.ToString();
                break;
            case PlayerSkillCtrl.skill.MagicArrow:
                GameManager.Instance.playerSkillCtrl.level_magicArrow++;
                hudSkill = hudSkillIcons[3];
                hudSkillLevels[3].text = GameManager.Instance.playerSkillCtrl.level_magicArrow.ToString();
                break;
            case PlayerSkillCtrl.skill.PunchHeavy:
                GameManager.Instance.playerSkillCtrl.level_punchHeavy++;
                hudSkill = hudSkillIcons[4];
                hudSkillLevels[4].text = GameManager.Instance.playerSkillCtrl.level_punchHeavy.ToString();
                break;
        }
        if(!hudSkill.activeSelf){
            hudSkill.SetActive(true);
        }
    }
}
