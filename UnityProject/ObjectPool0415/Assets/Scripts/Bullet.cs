using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PoolObject _poolObject;
    
    //속도
    [field: SerializeField] public float Speed { get; private set; } = 15;
    
    private void Awake()
    {
        _poolObject = GetComponent<PoolObject>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        //파티클 뿌리기
       EffectPool.Instance.GetPoolObject(transform.position, Quaternion.identity);
        
        //리턴하기
        if (_poolObject == null)
        {
            Destroy(gameObject);
        }
        else
        {
            _poolObject.ReturnToPool();
        }
    }


}
