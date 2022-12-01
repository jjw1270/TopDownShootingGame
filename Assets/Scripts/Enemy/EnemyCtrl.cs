using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    protected GameObject player;
    private Animator anim;
    protected bool isDie;
    public float DefaultHP;
    private float HP;
    public float speed = 1f;
    private float distance;
    private bool isAttack;
    public int damage = 10;
    private bool isKnockBack;
    private Rigidbody rb;
    private Collider coll;
    private Vector3 reactVec;
    virtual protected void Awake() {
        player = GameManager.Instance.Player;
        
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    private void OnEnable() {
        SetHP();
        StartCoroutine(GetDistance());
    }

    public void SetHP(){
        //경과 시간에 비례하여 체력 증가
        int playTimeMin = GameManager.Instance.playtimeSec / 60;

        if(playTimeMin < 5){
            HP = DefaultHP;
            return;
        }
        if(playTimeMin < 10){
            HP = DefaultHP * 2;
            return;
        }
        if(playTimeMin < 15){
            HP = DefaultHP * 3;
            return;
        }
        if(playTimeMin < 20){
            HP = DefaultHP * 5;
            return;
        }
    }

    private void Update() {
        if(isDie){
            return;
        }
        FollowTarget();
    }

    virtual protected void FollowTarget(){
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform);
    }

    virtual protected void Die(){
        if(isDie) return;
        isDie = true;

        rb.isKinematic = true;
        coll.enabled = false;

        anim.SetBool("isDie", true);

        Invoke("Disable", 1f);
    }

    private void Disable(){
        GameManager.Instance.enemyDeathCount++;
        //경험치 80%확률
        float percent = Random.Range(0,1f);
        if(percent < 0.8f){
            ObjectPooler.SpawnFromPool(GameManager.Instance.Exp, this.transform.position);
        }
        rb.isKinematic = false;
        coll.enabled = true;
        this.gameObject.SetActive(false);
    }

    private void OnDisable() {
        GameManager.Instance.currentEnemyCount--;
        StopCoroutine(GetDistance());
        ObjectPooler.ReturnToPool(gameObject);
    }

    IEnumerator GetDistance(){
        while(true){
            distance = Vector3.Distance(player.transform.position, this.transform.position);
            if(distance >= 40f){
                this.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(4f);
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.transform.CompareTag("Player")){
            if(!isAttack){
                //플레이어 데미지
                GameManager.Instance.playerHPCtrl.GetDamage(damage);
                isAttack =true;
                StartCoroutine(DamagePlayer());
            }
        }
    }
    
    IEnumerator DamagePlayer(){
        yield return new WaitForSeconds(1f);
        isAttack = false;
    }

    public void GetDamage(int damage){
        HP -= damage;

        reactVec = -(player.transform.position - this.transform.position);
        reactVec = reactVec.normalized;

        if(!isKnockBack){
            rb.AddForce(reactVec * 10, ForceMode.Impulse);
            isKnockBack = true;
            StartCoroutine(KnockBack());
        }
            

        if(HP <= 0){
            Die();
        }
    }

    IEnumerator KnockBack(){
        yield return new WaitForSeconds(0.5f);
        isKnockBack = false;
    }

}
