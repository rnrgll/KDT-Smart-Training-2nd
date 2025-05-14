using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankControl_Advance : MonoBehaviour
{
    //조작키
    [FormerlySerializedAs("shootKeyCode")]
    [Header("Key Control")]
    [SerializeField] private KeyCode autoShootKeyCode;
    [SerializeField] private KeyCode moveNorthKeyCode;
    [SerializeField] private KeyCode moveSouthdKeyCode;
    [SerializeField] private KeyCode moveEastKeycode;
    [SerializeField] private KeyCode moveWestKeycode;

    [Header("Speed Control")] 
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotateSpeed = 360;
     
    private WaitForSeconds _delay;
    private Coroutine _AutoShootCoroutine;
    
    private Shooter shooter;
    private Transform turret;

    [SerializeField] private float delayTime = 0.5f;
    
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        turret = GetComponentInChildren<TurretControl>().transform;
        
        _delay = new WaitForSeconds(delayTime);
        _AutoShootCoroutine = null;
    }

    // Update is called once per frame
    void Update()
    {
        //연사
        if (Input.GetKeyDown(autoShootKeyCode))
        {
            if (_AutoShootCoroutine == null)
            {
                _AutoShootCoroutine = StartCoroutine(AutoShootAfterDelay());
            }
        }

        if (Input.GetKeyUp(autoShootKeyCode))
        {
            if (_AutoShootCoroutine != null)
            {
                StopCoroutine(_AutoShootCoroutine);
                _AutoShootCoroutine = null;
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
    

    
    private void OnDestroy()
    {
        if (EffectPool.Instance != null)
        {
            EffectPool.Instance.GetPoolObject(transform.position, Quaternion.identity);
        }
           
    }
    
    
    private IEnumerator AutoShootAfterDelay()
    {
        while (true)
        {
            shooter.Shoot();

            yield return _delay;
        }
        
    }
    
    
    
}
