using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl_Mushroom : EnemyCtrl
{
    [SerializeField]private Animation animt;
    private const string DEATH = "Death";

    protected override void Die()
    {
        if(isDie == true) return;
        isDie = true;

        animt.Play(DEATH);

        Invoke("Disable", 1f);
    }
}
