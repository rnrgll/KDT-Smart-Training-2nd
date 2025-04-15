using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooter : MonoBehaviour
{
   
    //발사 오브젝트 프리팹
    [SerializeField] private GameObject bulletPrefab;
    //오브젝트 생성 위치
    [SerializeField] private Transform bulletSpawnPosition;
    
    
    //오브젝트 풀
    [SerializeField] private ObjectPool bulletPool;
    
    
    
    private void Awake()
    {
        
        
     
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Shoot()
    {
        GameObject bullet;
        if (bulletPool == null)
        {
            bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        }
        else
        {
            bullet = bulletPool.GetPoolObject(bulletSpawnPosition.position, bulletSpawnPosition.rotation).gameObject;
        }

        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPosition.forward * bullet.GetComponent<Bullet>().Speed; //방향, 속도 설정

    }
}
