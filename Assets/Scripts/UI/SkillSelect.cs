using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkillSelect : MonoBehaviour
{
    [SerializeField]private PlayerSkillCtrl.skill skill;
    [SerializeField]private GameObject newText;
    private void Awake() {
    }
    public bool isSkillLevelMax(){
        bool result = false;
        switch(skill){
            case PlayerSkillCtrl.skill.IceSpear:
                if(GameManager.Instance.playerSkillCtrl.level_iceSpear >= 5){
                    result = true;
                }
                break;
            case PlayerSkillCtrl.skill.SparkleBall:
                if(GameManager.Instance.playerSkillCtrl.level_sparkleBall >= 5){
                    result = true;
                }
                break;
            case PlayerSkillCtrl.skill.LightningStrike:
                if(GameManager.Instance.playerSkillCtrl.level_lightningStrike >= 5){
                    result = true;
                }
                break;
            case PlayerSkillCtrl.skill.MagicArrow:
                if(GameManager.Instance.playerSkillCtrl.level_magicArrow >= 5){
                    result = true;
                }
                break;
            case PlayerSkillCtrl.skill.PunchHeavy:
                if(GameManager.Instance.playerSkillCtrl.level_punchHeavy >= 5){
                    result = true;
                }
                break;
        }
        return result;
    }
    private void OnEnable() {
        switch(skill){
            case PlayerSkillCtrl.skill.IceSpear:
                if(GameManager.Instance.playerSkillCtrl.level_iceSpear == 0){
                    newText.SetActive(true);
                }
                break;
            case PlayerSkillCtrl.skill.SparkleBall:
                if(GameManager.Instance.playerSkillCtrl.level_sparkleBall == 0){
                    newText.SetActive(true);
                }
                break;
            case PlayerSkillCtrl.skill.LightningStrike:
                if(GameManager.Instance.playerSkillCtrl.level_lightningStrike == 0){
                    newText.SetActive(true);
                }
                break;
            case PlayerSkillCtrl.skill.MagicArrow:
                if(GameManager.Instance.playerSkillCtrl.level_magicArrow == 0){
                    newText.SetActive(true);
                }
                break;
            case PlayerSkillCtrl.skill.PunchHeavy:
                if(GameManager.Instance.playerSkillCtrl.level_punchHeavy == 0){
                    newText.SetActive(true);
                }
                break;
        }
    }

    public void OnSelected(){
        SoundManager.Instance.PlaySFXSound("Spell_00");
        GameManager.Instance.playerLevelCtrl.UpdateSkill(skill);
        GameManager.Instance.playerLevelCtrl.levelUpPanel.SetActive(false);
    }
    private void OnDisable(){
        if(newText.activeSelf){
            newText.SetActive(false);
        }
    }
}
