using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    //조작키
    [Header("Key Control")]
    [SerializeField] private KeyCode shootKeyCode;
    

    [Header("Speed Control")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    
    
   private Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKeyCode))
        {
            shooter.Shoot();
        }
        
        //움직임
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");
        
        //이동 거리 = 속도(방향 * 속력) * 시간
        float distance = moveInput * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * distance);
        
        //회전
        //axis = y축, angle
        float angle = rotateInput * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, angle);

    }
}
