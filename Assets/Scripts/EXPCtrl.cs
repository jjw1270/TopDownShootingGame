using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable() {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
