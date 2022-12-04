using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTxt : MonoBehaviour
{
    private void Start() {
        Destroy(this.gameObject, 0.5f);
    }
    private void Update() {
        this.transform.Translate(Vector3.up * Time.deltaTime * 1.5f);
    }
}
