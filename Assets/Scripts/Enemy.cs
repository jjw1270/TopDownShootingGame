using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    private Animator anim;
    private NavMeshAgent agent;
    private bool isDie;
    public float HP;

    private void Awake() {
        Player = GameManager.Instance.Player;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
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

    private void FollowTarget(){
        if(agent.destination != Player.transform.position){
            agent.SetDestination(Player.transform.position);
        }
        else{
            agent.SetDestination(transform.position);
        }
    }

    private void Die(){
        if(isDie == true) return;
        isDie = true;

        anim.SetBool("isDie", true);

        Destroy(this.gameObject, 1f);  //setactive
    }

    private void OnDisable() {
        
    }

}
