using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArrow : SkillBase
{
    private bool isAwake;
    const string MagicArrowHit = "MagicArrowHit";
    const string enableSound = "etfx_shoot_mystic";
    private List<GameObject> enemies;
    private float shortDistance;
    private GameObject target;
    [SerializeField]private float speed = 10;
    protected override void OnEnable() {
        base.OnEnable();

        if(!isAwake){
            isAwake = true;
            return;
        }

        //랜덤 적 찾기
        getTarget();

        SoundManager.Instance.PlaySFXSound(enableSound, 0.8f);
    }
    private void getTarget(){
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        int randomEnemy = Random.Range(0, enemies.Count);
        target = enemies[randomEnemy];
    }

    private void FixedUpdate() {
        if(!target.activeSelf || target == null){
            this.gameObject.SetActive(false);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(this.transform.position);
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if(!other.CompareTag("Enemy")) return;

        HitEffect();
        this.gameObject.SetActive(false);
    }
    public override void SetDamage()
    {
        damage = Random.Range(defaultDamage-15,defaultDamage+15) + (GameManager.Instance.playerLevelCtrl.playerLevel-1) * 10;
    }

    public override void HitEffect(){
        ObjectPooler.SpawnFromPool(MagicArrowHit, this.transform.position);
    }
}
