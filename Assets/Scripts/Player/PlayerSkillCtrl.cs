using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillCtrl : MonoBehaviour
{
    [SerializeField]private Transform onPlayerSkill;
    public Collider onScreenCollider;
    public Transform SP_forward;
    [SerializeField]private Transform SP_back;
    [SerializeField]private Transform SP_left;
    [SerializeField]private Transform SP_right;

    public enum skill{
        IceSpear, SparkleBall, LightningStrike, MagicArrow, PunchHeavy
    }

    const string IceSpear = "IceSpear";
    [SerializeField]private GameObject SparkleBall;
    const string LightningStrike = "LightningStrike";
    const string MagicArrow = "MagicArrow";
    const string PunchHeavy = "PunchHeavy";
    
    [HideInInspector]public int level_iceSpear = 0;
    [HideInInspector]public int level_sparkleBall = 0;
    [HideInInspector]public int level_lightningStrike = 0;
    [HideInInspector]public int level_magicArrow = 0;
    [HideInInspector]public int level_punchHeavy = 0;

    void Start()
    {
        StartCoroutine("ActiveSkill_IceSpear");
        StartCoroutine("ActiveSkill_SparkleBall");
        StartCoroutine("ActiveSkill_LightningStrike");
        StartCoroutine("ActiveSkill_MagicArrow");
        StartCoroutine("ActiveSkill_PunchHeavy");
    }

    IEnumerator ActiveSkill_IceSpear(){
        while(true){
            yield return new WaitForSeconds(1f);
            Skill_IceSpear(level_iceSpear);
            yield return new WaitForSeconds(2f);
        }
    }
    IEnumerator ActiveSkill_SparkleBall(){
        while(true){
            yield return new WaitForSeconds(1f);
            Skill_SparkleBall(level_sparkleBall);
            yield return new WaitForSeconds(19f);
        }
    }
    IEnumerator ActiveSkill_LightningStrike(){
        while(true){
            yield return new WaitForSeconds(1.5f);
            Skill_LightningStrike(level_lightningStrike);
        }
    }
    IEnumerator ActiveSkill_MagicArrow(){
        while(true){
            yield return new WaitForSeconds(1f);
            Skill_MagicArrow(level_magicArrow);
            yield return new WaitForSeconds(4f);
        }
    }
    IEnumerator ActiveSkill_PunchHeavy(){
        while(true){
            yield return new WaitForSeconds(2f);
            Skill_PunchHeavy(level_punchHeavy);
        }
    }

    private void Skill_IceSpear(int skillLevel){
        if(skillLevel == 0) return;

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
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_forward));
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
        if(skillLevel == 0) return;

        //localRotation 으로 바꿀 것
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
                Instantiate(SparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                break;
            case 2:
                Instantiate(SparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                break;
            case 3:
                Instantiate(SparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, leftVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, rightVec, Quaternion.identity, onPlayerSkill);
                break;
            case 4:
                Instantiate(SparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, leftVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, rightVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, flVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, brVec, Quaternion.identity, onPlayerSkill);
                break;
            case 5:
                Instantiate(SparkleBall, forwardVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, backVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, leftVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, rightVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, flVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, frVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, blVec, Quaternion.identity, onPlayerSkill);
                Instantiate(SparkleBall, brVec, Quaternion.identity, onPlayerSkill);
                break;
            default:
                return;
        }
    }

    private void Skill_LightningStrike(int skillLevel){
        if(skillLevel == 0) return;

        int strikeCount = 0;
        switch(skillLevel){
            case 1:
                strikeCount = 1;
                break;
            case 2:
                strikeCount = 2;
                break;
            case 3:
                strikeCount = 4;
                break;
            case 4:
                strikeCount = 6;
                break;
            case 5:
                strikeCount = 8;
                break;
            default:
                return;
        }

        for(int i = 0; i < strikeCount; i++){
            Vector3 randomPos = RandomPos();
            ObjectPooler.SpawnFromPool(LightningStrike, randomPos, Quaternion.identity);
        }
    }
    private Vector3 RandomPos(){
        Vector3 originPosition = onScreenCollider.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = onScreenCollider.bounds.size.x;
        float range_Z = onScreenCollider.bounds.size.z;
        
        range_X = Random.Range( (range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range( (range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0.5f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    private void Skill_MagicArrow(int skillLevel){
        if(skillLevel == 0) return;

        int arrowCount = (skillLevel-1) * 2 + 1;
        StartCoroutine(Arrow(arrowCount));
    }
    IEnumerator Arrow(int arrowCount){
        for(int i = 0; i < arrowCount; i++){
            ObjectPooler.SpawnFromPool(MagicArrow, SP_forward.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        yield return null;
    }

    private void Skill_PunchHeavy(int skillLevel){
        if(skillLevel == 0) return;

        Vector3 punchScale = new Vector3(2f, 2f, skillLevel);
        Vector3 colliderCenter = new Vector3(0, 0, skillLevel*0.7f);
        GameObject punchHeavy = ObjectPooler.SpawnFromPool(PunchHeavy, SP_forward.position, this.transform.rotation);
        punchHeavy.transform.localScale = punchScale;
        BoxCollider col = punchHeavy.GetComponent<BoxCollider>();
        col.size = punchScale;
        col.center = colliderCenter;
    }
}
