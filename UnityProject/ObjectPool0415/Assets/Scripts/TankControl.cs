using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    //조작키
    [SerializeField] private KeyCode shootKeyCode;
    [SerializeField] private Shooter shooter;

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
                
    }
}
