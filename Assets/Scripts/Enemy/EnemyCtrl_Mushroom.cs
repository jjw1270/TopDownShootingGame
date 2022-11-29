using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl_Mushroom : EnemyCtrl
{
    private Animation animt;
    public const string DEATH = "Death";

    protected override void Awake()
    {
        player = GameManager.Instance.Player;
        animt = GetComponent<Animation>();
    }

    protected override void Die()
    {
        if(isDie == true) return;
        isDie = true;

        animt.Play(DEATH);

        Invoke("Disable", 1f);
    }
}
