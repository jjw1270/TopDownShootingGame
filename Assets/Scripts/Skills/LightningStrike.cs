using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : SkillBase
{
    private bool isAwake;
    const string LightningStrikeHit = "LightningStrikeHit";
    const string enableSound = "etfx_shoot_lightning";
    protected override void OnEnable() {
        base.OnEnable();

        if(!isAwake){
            isAwake = true;
            return;
        }

        SoundManager.Instance.PlaySFXSound(enableSound, 0.3f/GameManager.Instance.playerSkillCtrl.level_lightningStrike);
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        
        HitEffect();
    }

    public override void HitEffect(){
        ObjectPooler.SpawnFromPool(LightningStrikeHit, this.transform.position);
    }

}
