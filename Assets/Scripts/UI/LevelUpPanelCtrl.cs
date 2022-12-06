using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelUpPanelCtrl : MonoBehaviour
{
    [SerializeField]private SkillSelect[] skills = new SkillSelect[5];
    private List<SkillSelect> tmpSkills;
    [SerializeField]private GameObject effect;

    private void OnEnable() {
        effect.SetActive(true);
        Time.timeScale = 0f;
        tmpSkills = new List<SkillSelect>();
        tmpSkills.AddRange(skills);
        ShowRandomSkills();
    }

    private void ShowRandomSkills(){
        for(int i = 0; i < skills.Length; i++){
            if(skills[i].isSkillLevelMax()){
                tmpSkills.Remove(skills[i]);
            }
        }
        for(int i = 0; i < 3; ){
            if(tmpSkills.Count<=0) break;

            int randomIndex = Random.Range(0,tmpSkills.Count);
            if(tmpSkills[randomIndex].gameObject.activeSelf) continue;
            tmpSkills[randomIndex].gameObject.SetActive(true);
            tmpSkills.Remove(tmpSkills[randomIndex]);
            i++;
        }
    }

    private void OnDisable() {
        foreach(var skill in skills){
            skill.gameObject.SetActive(false);
        }
        tmpSkills = null;
        Time.timeScale = 1f;
        effect.SetActive(false);
    }
}
