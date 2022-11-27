using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCtrl : Enemy
{
    private Animation animt;
    public const string DEATH = "Death";

    protected override void Awake()
    {
        Player = GameManager.Instance.Player;
        animt = GetComponent<Animation>();
    }

    protected override void Die()
    {
        if(isDie == true) return;
        isDie = true;

        animt.Play(DEATH);

        Destroy(this.gameObject, 1f);  //setactive
    }
}
