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

        switch(GameManager.Instance.skillCtrl.level_iceSpear){
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
        
        //damage = 플레이어 레벨에 비례하여 증가
        damage = (int)(damage * GameManager.Instance.playerLevel * 1.2f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected override void OnCollisionEnter(Collision other) {
        base.OnCollisionEnter(other);
        
        HitEffect();
        this.gameObject.SetActive(false);
    }

    public override void HitEffect(){
        ObjectPooler.SpawnFromPool(IceSpearHit, this.transform.position);
    }
}
