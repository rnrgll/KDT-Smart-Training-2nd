using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPool : ObjectPool
{
    public static EffectPool Instance { get; private set; }

    protected override void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        base.Awake();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
