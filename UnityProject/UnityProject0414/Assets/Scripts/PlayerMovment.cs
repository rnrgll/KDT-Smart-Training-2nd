using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private Transform startPosition;

    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = startPosition.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        
        Vector3 moveDir = new Vector3(h, 0f, v);
        rb.velocity = moveDir * moveSpeed;

    }
}
