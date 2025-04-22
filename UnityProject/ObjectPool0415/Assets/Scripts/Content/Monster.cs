using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [SerializeField] private Transform targetTransform;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float rotateSpeed = 8f;
    [SerializeField] private float stopDistance = 1.5f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTransform == null) return;
        
        Vector3 direction = targetTransform.position - transform.position;
        float distance = direction.magnitude;
        
        // 일정 거리 이하로 가까워지면 멈추도록 처리
        if (distance < stopDistance)
            return;
        
        
        direction.Normalize();
      
        
        //장애물 감지
        Ray ray = new Ray(transform.position, direction);
        Debug.DrawRay(transform.position,direction*distance, Color.green);
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            if (!hit.collider.CompareTag("Tank"))
            {
                Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
                return;
            }
        }


        //장애물 없으면 이동
        transform.position =
                Vector3.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
        
        //회전
        float angleY = Vector3.SignedAngle(transform.forward, direction, Vector3.up);
        
        //회전 속도 제한
        float maxRotate = rotateSpeed * Time.deltaTime;
        float clampAngle = Math.Clamp(angleY, -maxRotate, maxRotate);
        
        transform.Rotate(Vector3.up, clampAngle);


    }
}
