using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FloatingJoystick joystick;
    public float playerSpeed = 7;
    Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        direction = direction.normalized;

        this.transform.position += direction * playerSpeed * Time.deltaTime;

        anim.SetBool("isRun", direction != Vector3.zero);

        transform.LookAt(transform.position + direction);
    }
}
