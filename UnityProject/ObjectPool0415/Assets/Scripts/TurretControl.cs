using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    [Header("Key Control")]
    [SerializeField] private KeyCode rotateRightKeycode;
    [SerializeField] private KeyCode rotateLeftKeycode;
    
    [Header("Turret Rotate Control")] 
    [SerializeField] private float turretRotateSpeed = 60f;
    [SerializeField] private float maxTurretAngle = 135f;
    
    private TankControl_Advance tankControl;

    private void Awake()
    {
        tankControl = GetComponentInParent<TankControl_Advance>();
    }

    // 터렛 회전이랑, trank control에서 회전 복원하는거랑 충돌 날 수 있으니 late update로 옮기기..?
    void LateUpdate()
    {
        float w = 0f;
        if (Input.GetKey(rotateRightKeycode))
        {
            w += 1f;
        }

        if (Input.GetKey(rotateLeftKeycode))
        {
            w -= 1f;
        }

        if (w != 0f)
        {
            //회전량
            float delatAngle = w * turretRotateSpeed * Time.deltaTime;
        
            //현재 회전 각도 구하기
            //tank 몸체를 기준으로 회전 각도를 구하기
            float currentAngle = Vector3.SignedAngle(tankControl.transform.forward, transform.forward, Vector3.up);
        
            //다음 회전 각도 = 현재 회전 각도 + delta
            float nextAngle = currentAngle + delatAngle;
            
            //범위 보정
            nextAngle = Mathf.Clamp(nextAngle, -maxTurretAngle, +maxTurretAngle);
            
            //최종 회전해야할 회전량 = 보정된 각도 - 현재 각도
            float finalAngle = nextAngle - currentAngle;
        
            
            //회전 적용
            transform.Rotate(Vector3.up, finalAngle);
        }
     
    }
}
