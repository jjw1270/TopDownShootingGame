using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : DisableAfterSec
{
    public int defaultDamage;
    private int damage = 0;
    public abstract void HitEffect();

    protected override void OnEnable() {
        base.OnEnable();
        //damage = 플레이어 레벨에 비례하여 증가
        damage = Random.Range(defaultDamage-15,defaultDamage+15) + (int)(GameManager.Instance.playerLevel * 1.2f);
    }

    protected virtual void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Enemy")) return;

        other.GetComponent<EnemyCtrl>().GetDamage(damage);
    }

}
