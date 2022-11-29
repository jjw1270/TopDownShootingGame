using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCtrl : MonoBehaviour
{
    [SerializeField]private FloatingJoystick joystick;
    [SerializeField]private float playerSpeed = 7;
    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        if(GameManager.Instance.playerHPCtrl.isPlayerDie)
            return;

        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        direction = direction.normalized;

        this.transform.position += direction * playerSpeed * Time.deltaTime;

        anim.SetBool("isRun", direction != Vector3.zero);

        transform.LookAt(transform.position + direction);
    }
}
