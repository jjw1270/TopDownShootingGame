using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderCtrl : Enemy
{
    bool lookTarget;
    Vector3 targetVec;
    protected override void FollowTarget() {
        if(!lookTarget){
            lookTarget = true;
            targetVec = (Player.transform.position - this.transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(targetVec);
            transform.rotation = rot;
        }

        transform.Translate(targetVec * speed * Time.deltaTime, Space.World);
    }
}