using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpear : SkillBase
{
    private float power = 20f;
    const string IceSpearHit = "IceSpearHit";

    protected override void OnEnable() {
        base.OnEnable();
        //damage = 플레이어 레벨에 비례하여 증가
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * power * Time.deltaTime);
    }

    public override void HitEffect(){
        ObjectPooler.SpawnFromPool(IceSpearHit, this.transform.position);
    }
}
