using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PoolObject _poolObject;
    
    //속도
    [field: SerializeField] public float Speed { get; private set; } = 15;
    
    
    //데미지
    [SerializeField] private int damage = 1;
    
    
    
    private void Awake()
    {
        _poolObject = GetComponent<PoolObject>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"<color=yellow>{other.name}</color>");
        //파티클 뿌리기
       EffectPool.Instance.GetPoolObject(transform.position, Quaternion.identity);
       
       Debug.Log($"총알 충돌 : {other.name}");
       if (other.TryGetComponent<IDamagable>(out IDamagable target))
       {
           target.TakeDamage(gameObject ,damage);
           
       }
       
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
