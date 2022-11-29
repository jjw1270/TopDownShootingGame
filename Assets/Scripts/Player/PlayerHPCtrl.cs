using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHPCtrl : MonoBehaviour
{
    private Animator anim;
    [SerializeField]private Slider hpBar;
    public float maxHp = 100f;
    [SerializeField]private float currentHp;
    [SerializeField]private Renderer rend;
    [SerializeField]private Color hitColor;
    private Color defaultColor;
    public bool isPlayerDie = false;

    private void Awake() {
        defaultColor = rend.material.color;
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHp = 100f;
        hpBar.value = currentHp / maxHp;
    }

    public void GetDamage(int damage){
        if(isPlayerDie) return;

        StartCoroutine(HitColor());

        currentHp-=damage;
        hpBar.value = currentHp / maxHp;
        if(currentHp<= 0){
            Die();
        }
    }

    IEnumerator HitColor(){
        rend.material.color = hitColor;
        yield return new WaitForSeconds(0.2f);
        rend.material.color = defaultColor;
    }

    private void Die(){
        anim.SetBool("isDie", true);
        isPlayerDie = true;
        GameManager.Instance.GameOver();
    }
}
