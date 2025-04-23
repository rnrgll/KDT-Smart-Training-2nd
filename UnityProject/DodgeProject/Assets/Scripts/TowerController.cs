using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Pool;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TowerController : MonoBehaviour
{
    [Header("Detect")]
    [SerializeField] private float detectRadius;
    [SerializeField] private LayerMask targetLayer;

    [Header("Rotate")]
    [SerializeField] private float rotateSpeed;
    
    [Header("Attack")]
    [SerializeField] private float fireRate;
    [SerializeField] private Transform muzzleTransform;
    private Coroutine fireCoroutine = null;
    
    [Header("Pool")]
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private Transform poolTransform;
    
    
    private IObjectPool<BulletController> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<BulletController>(
            CreateBullet,
            OnGetBullet,
            OnReleaseBullet,
            OnDestroyBullet,
            collectionCheck: true,
            defaultCapacity: poolSize,
            maxSize: poolSize+10
        );

        
    }

    private void Update()
    {
        DetectPlayer();
    }

    #region BulletPool

    private BulletController CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetPool(bulletPool);
        bullet.transform.SetParent(poolTransform);
        return bullet;
    }

    private void OnGetBullet(BulletController bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(BulletController bullet)
    {
        //안보이게
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(BulletController bullet)
    {
        Destroy(bullet.gameObject);
    }


    #endregion

    private void DetectPlayer()
    {
        //감지할 영역에 플레이어가 있으면
        //플레이어를 바라보고
        //공격(탄환을 풀에서 가져온다)
        
        //1. 감지 시스템 : 감지 범위(원형) 안에 플레이어가 있는지 확인하자.
        //layer mask 활용
        //조건에 맞는 Collider[] 반환함
        Collider[] targets = Physics.OverlapSphere(transform.position, detectRadius, targetLayer);
        
        bool isDetect = false;
        foreach (var target in targets)
        {
            if (target.CompareTag("Player"))
            {
                //플레이어를 바라본다.
                Vector3 playerPos = target.transform.position;
                //lookAt 메소드를 사용하는데, y방향 회전은 안되도록 처리
                Vector3 targetPos = new Vector3(playerPos.x, transform.position.y, playerPos.z);
                transform.LookAt(targetPos);
        
                //공격 대기 중이 아니라면 공격한다.
                if (fireCoroutine == null)
                {
                    fireCoroutine = StartCoroutine(Fire());
                }

                isDetect = true;
            
                return;
            }
        }

        if (!isDetect)
        {
            //회전
            transform.Rotate(Vector3.up, rotateSpeed* Time.deltaTime);
        
            //공격 대기 & 공격 처리하는 코루틴 멈추기
            if (fireCoroutine != null)
            {
                StopCoroutine(fireCoroutine);
                fireCoroutine = null;
            }
        }

        
    }
    
    private IEnumerator Fire()
    {
        while (true)
        {
            var bullet = bulletPool.Get();
            bullet.transform.position = muzzleTransform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.Shoot(transform.forward);

            yield return new WaitForSeconds(fireRate);
        }
     
    }
    
    
    
    
    //detect 반경 디버깅용
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
