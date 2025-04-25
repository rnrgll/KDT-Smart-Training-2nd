using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankControl_Advance_Charging : MonoBehaviour
{
    //조작키
    [FormerlySerializedAs("autoShootKeyCode")]
    [FormerlySerializedAs("shootKeyCode")]
    [Header("Key Control")]
    [SerializeField] private KeyCode chargingShootKeyCode;
    [SerializeField] private KeyCode moveNorthKeyCode;
    [SerializeField] private KeyCode moveSouthdKeyCode;
    [SerializeField] private KeyCode moveEastKeycode;
    [SerializeField] private KeyCode moveWestKeycode;

    [Header("Speed Control")] 
    [SerializeField] private float moveSpeed = 10;

    [SerializeField] private float rotateSpeed = 360;


    private Coroutine chargingCoroutine;
    
    
   private Shooter shooter;
   private Transform turret;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        turret = GetComponentInChildren<TurretControl>().transform;

        chargingCoroutine = null;
    }

    // Update is called once per frame
    void Update()
    {
        //연사
        if (Input.GetKeyDown(chargingShootKeyCode))
        {
            if (chargingCoroutine == null)
            {
                chargingCoroutine = StartCoroutine(ChargingShoot());
            }
        }


        float x = 0, z = 0;
        if(Input.GetKey(moveNorthKeyCode)) z += 1f;
        if(Input.GetKey(moveSouthdKeyCode)) z -= 1f;
        if(Input.GetKey(moveEastKeycode)) x += 1f;
        if(Input.GetKey(moveWestKeycode)) x -= 1f;

        Vector3 moveDirection = new Vector3(x, 0, z).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        
        //자동 회전 처리
        if (moveDirection!=Vector3.zero && moveDirection != transform.forward)
        {
            //-----터렛 회전 같이 안되도록 코드 추가----//
            //1. 터렛 회전값 저장하기
            Quaternion turretRotation = turret.rotation;
            
            
            //2. 몸체 회전 계산
            //움직이는 방향을 바라보는 회전값 구하기
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            
            //회전값이 거의 같으면 회전 안하게 하기(float 오차로 인한 무한 회전 방지)
            if (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
            {
                
                //회전 시키기 (부드럽게 회전처리 -> from 에서 to 까지 일정 속도로)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            }
            
            
            //3. 터렛 회전값 복원
            turret.rotation = turretRotation;


        }
        
    }
    
    
    //충돌
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(EffectPool.Instance!=null)
           EffectPool.Instance.GetPoolObject(transform.position, Quaternion.identity);
    }
    
    
    private IEnumerator ChargingShoot()
    {
        float time = 0f;
        while (true)
        {
            time += Time.deltaTime * 30;
            yield return null;

            if (Input.GetKeyUp(chargingShootKeyCode))
                break;
        }

        float speed = Mathf.Clamp(time, 10f, 30f);

        shooter.Shoot(speed);
        chargingCoroutine = null;
    }
}
