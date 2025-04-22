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
        var main = _particleSystem.main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }


    protected override void OnEnable()
    {
        _particleSystem.Play();
    }

    protected override void Update()
    {
        //
    }

    // private IEnumerator ReturnAfterParticlePlay()
    // {
    //     _particleSystem.Play();
    //     yield return new WaitWhile(() => _particleSystem.isPlaying);
    //     ReturnToPool();
    // }
    
    //코루틴이 아닌 콜백 방식으로 오브젝트 풀 반환 구현
    private void OnParticleSystemStopped()
    {
        ReturnToPool();
    }
}
