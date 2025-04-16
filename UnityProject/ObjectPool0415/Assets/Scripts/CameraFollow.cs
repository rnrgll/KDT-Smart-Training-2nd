using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    private Vector3 positionOffset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        positionOffset = transform.position - targetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = targetTransform.position + positionOffset;
    }
}
