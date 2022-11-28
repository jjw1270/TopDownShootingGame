using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    private Animator anim;
    protected bool isDie;
    public float DefaultHP;
    private float HP;
    public float speed = 1f;
    private int minTimer;

    virtual protected void Awake() {
        player = GameManager.Instance.Player;
        
        anim = GetComponent<Animator>();
    }

    private void OnEnable() {
        SetHP();
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
            HP = DefaultHP * 4;
            return;
        }
        if(playTimeMin < 20){
            HP = DefaultHP * 8;
            return;
        }
    }

    private void Update() {
        if(HP<=0){
            Die();
        }
        else{
            FollowTarget();
        }
    }

    virtual protected void FollowTarget(){
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform);
    }

    virtual protected void Die(){
        if(isDie == true) return;
        isDie = true;

        anim.SetBool("isDie", true);

        Invoke("Disable", 1f);
    }

    private void Disable(){
        this.gameObject.SetActive(false);
        //경험치 생성
    }

    private void OnDisable() {
        ObjectPooler.ReturnToPool(gameObject);
    }

}
