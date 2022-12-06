using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpear : SkillBase
{
    private bool isAwake;
    private float speed = 20f;
    const string IceSpearHit = "IceSpearHit";
    const string enableSound = "etfx_shoot_storm";
    
    protected override void OnEnable() {
        base.OnEnable();

        if(!isAwake){
            isAwake = true;
            return;
        }
        SoundManager.Instance.PlaySFXSound(enableSound, 1f/GameManager.Instance.playerSkillCtrl.level_iceSpear);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        
        HitEffect();
    }
    public override void SetDamage()
    {
        damage = Random.Range(defaultDamage-15,defaultDamage+15) + (GameManager.Instance.playerLevelCtrl.playerLevel-1) * 8;
    }

    public override void HitEffect(){
        ObjectPooler.SpawnFromPool(IceSpearHit, this.transform.position);
    }
}
