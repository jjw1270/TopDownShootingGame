using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleBall : SkillBase
{
    private bool isAwake;
    private float speed = 100f;
    const string SparkleBallHit = "SparkleBallHit";
    const string enableSound = "etfx_shoot_rocket03";
    
    protected override void OnEnable() {
        base.OnEnable();

        if(!isAwake){
            isAwake = true;
            return;
        }

        SoundManager.Instance.PlaySFXSound(enableSound, 1f/GameManager.Instance.playerSkillCtrl.level_sparkleBall);
    }

    private void FixedUpdate()
    {
        this.transform.RotateAround(GameManager.Instance.Player.transform.position, Vector3.up, speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        
        HitEffect();
    }

    public override void HitEffect(){
        ObjectPooler.SpawnFromPool(SparkleBallHit, this.transform.position);
    }

    protected override void OnDisable()
    {
        StopCoroutine(disableCoroutine);
    }
}
