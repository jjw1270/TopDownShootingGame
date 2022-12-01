using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : MonoBehaviour
{
    [SerializeField]private Transform onPlayerSkill;
    [SerializeField]private Transform SP_forward;
    [SerializeField]private Transform SP_back;
    [SerializeField]private Transform SP_left;
    [SerializeField]private Transform SP_right;

    const string IceSpear = "IceSpear";
    const string SparkleBall = "SparkleBall";
    [SerializeField]private GameObject sparkleBall;
    
    public int level_iceSpear = 1;
    public int level_sparkleBall = 1;
    

    void Start()
    {
        //StartCoroutine()
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Skill_IceSpear(level_iceSpear);
            Skill_SparkleBall(level_sparkleBall);
        }
    }


    private void Skill_IceSpear(int skillLevel){
        Vector3 rot_forward = this.transform.rotation.eulerAngles;
        Vector3 rot_back = new Vector3(rot_forward.x, rot_forward.y-180, rot_forward.z);
        Vector3 rot_left = new Vector3(rot_forward.x, rot_forward.y-90, rot_forward.z);
        Vector3 rot_right = new Vector3(rot_forward.x, rot_forward.y+90, rot_forward.z);
        
        Vector3 rot_fl = new Vector3(rot_forward.x, rot_forward.y-45, rot_forward.z);
        Vector3 rot_fr = new Vector3(rot_forward.x, rot_forward.y+45, rot_forward.z);
        Vector3 rot_bl = new Vector3(rot_forward.x, rot_forward.y+135, rot_forward.z);
        Vector3 rot_br = new Vector3(rot_forward.x, rot_forward.y-135, rot_forward.z);

        switch(skillLevel){
            case 1:
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, this.transform.rotation);
                break;
            case 2:
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_forward));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_back));
                break;
            case 3:
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_forward));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_back));
                ObjectPooler.SpawnFromPool(IceSpear, SP_left.position, Quaternion.Euler(rot_left));
                ObjectPooler.SpawnFromPool(IceSpear, SP_right.position, Quaternion.Euler(rot_right));
                break;
            case 4:
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_forward));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_back));
                ObjectPooler.SpawnFromPool(IceSpear, SP_left.position, Quaternion.Euler(rot_left));
                ObjectPooler.SpawnFromPool(IceSpear, SP_right.position, Quaternion.Euler(rot_right));
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fl));
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fr));
                break;
            case 5:
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_forward));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_back));
                ObjectPooler.SpawnFromPool(IceSpear, SP_left.position, Quaternion.Euler(rot_left));
                ObjectPooler.SpawnFromPool(IceSpear, SP_right.position, Quaternion.Euler(rot_right));
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fl));
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fr));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_bl));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_br));
                break;
        }
    }

    private void Skill_SparkleBall(int skillLevel){
        Vector3 forwardVec = new Vector3(this.transform.position.x, 1, this.transform.position.z + 5f);
        Vector3 backVec = new Vector3(this.transform.position.x, 1, this.transform.position.z - 5f);
        Vector3 leftVec = new Vector3(this.transform.position.x - 5f, 1, this.transform.position.z);
        Vector3 rightVec = new Vector3(this.transform.position.x + 5f, 1, this.transform.position.z);

        Vector3 flVec = new Vector3(this.transform.position.x - 3.5f, 1, this.transform.position.z + 3.5f);
        Vector3 frVec = new Vector3(this.transform.position.x + 3.5f, 1, this.transform.position.z + 3.5f);
        Vector3 blVec = new Vector3(this.transform.position.x - 3.5f, 1, this.transform.position.z - 3.5f);
        Vector3 brVec = new Vector3(this.transform.position.x + 3.5f, 1, this.transform.position.z - 3.5f);

        switch(skillLevel){
            case 1:
                Instantiate(sparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                break;
            case 2:
                Instantiate(sparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                break;
            case 3:
                Instantiate(sparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, leftVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, rightVec, Quaternion.identity, onPlayerSkill);
                break;
            case 4:
                Instantiate(sparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, leftVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, rightVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, flVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, brVec, Quaternion.identity, onPlayerSkill);
                break;
            case 5:
                Instantiate(sparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, leftVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, rightVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, flVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, frVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, blVec, Quaternion.identity, onPlayerSkill);
                Instantiate(sparkleBall, brVec, Quaternion.identity, onPlayerSkill);
                break;
        }
    }
}
