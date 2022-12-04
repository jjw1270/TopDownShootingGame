using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHeavy : SkillBase
{
    private bool isAwake;
    const string PunchHeavyHit = "PunchHeavyHit";
    const string enableSound = "etfx_shoot_frost";
    
    protected override void OnEnable() {
        base.OnEnable();

        if(!isAwake){
            isAwake = true;
            return;
        }

        SoundManager.Instance.PlaySFXSound(enableSound, 0.5f);
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);

        HitEffect(other.transform);
    }

    private void FixedUpdate() {
        this.transform.position = GameManager.Instance.skillCtrl.SP_forward.transform.position;
    }

    public override void HitEffect(){
    }
    public void HitEffect(Transform other){
        Vector3 pos = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, other.transform.position.z);
        ObjectPooler.SpawnFromPool(PunchHeavyHit, pos);
    }
}
