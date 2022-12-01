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

        switch(GameManager.Instance.skillCtrl.level_sparkleBall){
            case 1:
                SoundManager.Instance.PlaySFXSound(enableSound);
                break;
            case 2:
                SoundManager.Instance.PlaySFXSound(enableSound, 0.5f);
                break;
            case 3:
                SoundManager.Instance.PlaySFXSound(enableSound, 0.33f);
                break;
            case 4:
                SoundManager.Instance.PlaySFXSound(enableSound, 0.25f);
                break;
            case 5:
                SoundManager.Instance.PlaySFXSound(enableSound, 0.2f);
                break;
        }
    }

    private void FixedUpdate()
    {
        this.transform.RotateAround(GameManager.Instance.Player.transform.position, Vector3.up, speed * Time.deltaTime);
    }

    protected override void OnCollisionEnter(Collision other) {
        base.OnCollisionEnter(other);
        
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
