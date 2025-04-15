using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolEffect : PoolObject
{
    // Start is called before the first frame update
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }


    protected override void OnEnable()
    {
        StartCoroutine(ReturnAfterParticlePlay());
    }

    protected override void Update()
    {
        //
    }

    private IEnumerator ReturnAfterParticlePlay()
    {
        _particleSystem.Play();
        yield return new WaitWhile(() => _particleSystem.isPlaying);
        ReturnToPool();
    }
}
