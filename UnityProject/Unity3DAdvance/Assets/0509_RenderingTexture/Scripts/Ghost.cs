using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & playerLayerMask.value) > 0)
        {
            Debug.Log("유령과 충돌");
            other.GetComponent<PlayerControl>().Die();
        }
    }
}
