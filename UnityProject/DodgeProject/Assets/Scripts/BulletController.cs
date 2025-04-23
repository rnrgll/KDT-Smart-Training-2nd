using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class BulletController : MonoBehaviour
{
    private IObjectPool<BulletController> returnPool;
    private Rigidbody rb;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float returnTime;
    [SerializeField] private int attackDamage;

    private Coroutine returnCoroutine;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void SetPool(IObjectPool<BulletController> pool)
    {
        returnPool = pool;
    }

    public void Shoot(Vector3 direction)
    {
        rb.velocity = direction.normalized * moveSpeed;
        returnCoroutine = StartCoroutine(AutoRelease());

    }

    private IEnumerator AutoRelease()
    {
        yield return new WaitForSeconds(returnTime);
        ReturnToPool();
        
    }

    private void ReturnToPool()
    {
        if (returnCoroutine != null)
        {
            StopCoroutine(returnCoroutine);
            returnCoroutine = null;
        }
        returnPool.Release(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("bulletTarget"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //플레이어랑 충돌나면 피격
                other.GetComponent<PlayerController>().OnAttacked(attackDamage);
            }
      
            //풀로 돌아가기
            ReturnToPool();
        }
        
        
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
