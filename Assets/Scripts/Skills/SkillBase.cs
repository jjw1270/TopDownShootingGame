using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : DisableAfterSec
{
    public int damage;
    public abstract void HitEffect();

    protected virtual void OnCollisionEnter(Collision other){
        if(!other.transform.CompareTag("Enemy")) return;

        other.transform.GetComponent<EnemyCtrl>().GetDamage(damage);
    }

}
