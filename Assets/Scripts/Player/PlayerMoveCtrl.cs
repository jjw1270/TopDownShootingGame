using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCtrl : MonoBehaviour
{
    //[SerializeField]private FloatingJoystick joystick;
    [SerializeField]private float playerSpeed = 6;
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if(GameManager.Instance.playerHPCtrl.isPlayerDie)
            return;

        //Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(h, 0 , v);

        direction = direction.normalized;

        this.transform.position += direction * playerSpeed * Time.deltaTime;

        anim.SetBool("isRun", direction != Vector3.zero);

        transform.LookAt(transform.position + direction);
    }
}
