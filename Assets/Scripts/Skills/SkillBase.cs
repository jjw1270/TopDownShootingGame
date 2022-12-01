using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : DisableAfterSec
{
    public int damage;
    public abstract void HitEffect();

    protected virtual void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Enemy")) return;

        other.GetComponent<EnemyCtrl>().GetDamage(damage);
    }

}
