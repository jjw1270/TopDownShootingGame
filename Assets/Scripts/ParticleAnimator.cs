using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnimator : MonoBehaviour
{
    private double lastTime;
    private ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        lastTime = Time.realtimeSinceStartup;
    }

    void Update()
    {

        float deltaTime = Time.realtimeSinceStartup - (float)lastTime;

        particle.Simulate(deltaTime, true, false); //last must be false!!

        lastTime = Time.realtimeSinceStartup;
    }
}
