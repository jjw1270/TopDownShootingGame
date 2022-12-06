using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : DisableAfterSec
{
    public int defaultDamage;
    protected int damage = 0;  //플레이어 레벨에 비례하여 증가
    public abstract void HitEffect();

    public abstract void SetDamage();
    protected virtual void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Enemy")) return;
        SetDamage();
        other.GetComponent<EnemyCtrl>().GetDamage(damage);
    }

}
