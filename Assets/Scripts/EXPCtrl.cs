using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPCtrl : DisableAfterSec
{
    public float acceleration = 0.2f;
    private Vector3 dir;
    private float velocity;
    
    void Update()
    {
        CoinMove();
    }

    public void CoinMove(){
		dir = (GameManager.Instance.Player.transform.position - transform.position).normalized;
		velocity = (velocity + acceleration* Time.deltaTime);
		float distance = Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position);

        if (distance <= 4.0f){
            transform.position = new Vector3(transform.position.x + (dir.x * velocity),
            transform.position.y,
            transform.position.z+(dir.z * velocity));
        }
        else{
            velocity = 0.0f;
        }
    }
}
