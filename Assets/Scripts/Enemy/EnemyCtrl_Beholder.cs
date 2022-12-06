using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl_Beholder : EnemyCtrl
{
    private bool lookTarget;
    private Vector3 targetVec;
    
    protected override void FollowTarget() {
        if(!lookTarget){
            lookTarget = true;
            targetVec = (player.transform.position - this.transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(targetVec);
            transform.rotation = rot;
        }

        transform.Translate(targetVec * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.LookRotation(targetVec);
    }
}
