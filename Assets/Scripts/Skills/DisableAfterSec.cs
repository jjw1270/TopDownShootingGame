using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSec : MonoBehaviour
{
    [SerializeField]private float disableSec = 1f;
    protected Coroutine disableCoroutine;
    virtual protected void OnEnable() {
        disableCoroutine = StartCoroutine(Disable(disableSec));
    }

    IEnumerator Disable(float sec){
        yield return new WaitForSeconds(sec);
        this.gameObject.SetActive(false);
    }

    protected virtual void OnDisable() {
        //StopCoroutine(disableCoroutine);
        ObjectPooler.ReturnToPool(gameObject);
    }
}
