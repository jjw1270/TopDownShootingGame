using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject Player;
    private Animator anim;
    protected bool isDie;
    public float HP;
    public float speed = 1f;

    virtual protected void Awake() {
        Player = GameManager.Instance.Player;
        anim = GetComponent<Animator>();
    }

    private void OnEnable() {
        
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
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        transform.LookAt(Player.transform);
    }

    virtual protected void Die(){
        if(isDie == true) return;
        isDie = true;

        anim.SetBool("isDie", true);

        Destroy(this.gameObject, 1f);  //setactive
    }

    private void OnDisable() {
        
    }

}
