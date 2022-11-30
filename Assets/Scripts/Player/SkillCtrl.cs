using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : MonoBehaviour
{
    [SerializeField]private Transform SP_forward;
    [SerializeField]private Transform SP_back;
    [SerializeField]private Transform SP_left;
    [SerializeField]private Transform SP_right;

    [SerializeField]private GameObject iceSpear;

    const string IceSpear = "IceSpear";
    
    public int level_iceSpear = 1;

    void Start()
    {
        //StartCoroutine()
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Skill_IceSpear(level_iceSpear);
        }
    }

    private void Skill_IceSpear(int skillLevel){
        Vector3 rot_forward = this.transform.rotation.eulerAngles;
        Vector3 rot_back = new Vector3(rot_forward.x, rot_forward.y-180, rot_forward.z);
        Vector3 rot_left = new Vector3(rot_forward.x, rot_forward.y-90, rot_forward.z);
        Vector3 rot_right = new Vector3(rot_forward.x, rot_forward.y+90, rot_forward.z);
        
        Vector3 rot_fr = new Vector3(rot_forward.x, rot_forward.y+45, rot_forward.z);
        Vector3 rot_fl = new Vector3(rot_forward.x, rot_forward.y-45, rot_forward.z);
        Vector3 rot_br = new Vector3(rot_forward.x, rot_forward.y-135, rot_forward.z);
        Vector3 rot_bl = new Vector3(rot_forward.x, rot_forward.y+135, rot_forward.z);
        
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
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fr));
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fl));
                break;
            case 5:
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_forward));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_back));
                ObjectPooler.SpawnFromPool(IceSpear, SP_left.position, Quaternion.Euler(rot_left));
                ObjectPooler.SpawnFromPool(IceSpear, SP_right.position, Quaternion.Euler(rot_right));
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fr));
                ObjectPooler.SpawnFromPool(IceSpear, SP_forward.position, Quaternion.Euler(rot_fl));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_br));
                ObjectPooler.SpawnFromPool(IceSpear, SP_back.position, Quaternion.Euler(rot_bl));
                break;
        }
    }
}
