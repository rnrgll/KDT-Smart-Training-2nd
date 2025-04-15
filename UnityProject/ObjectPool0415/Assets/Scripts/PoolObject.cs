using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PoolObject : MonoBehaviour
{
    [FormerlySerializedAs("retrunPool")] public ObjectPool returnPool;
    [SerializeField] private float returnTime;
    private float elapsed = 0f;
    protected virtual void OnEnable()
    {
        elapsed = returnTime;
    }

    protected virtual void Update()
    {
        elapsed -= Time.deltaTime;
        if (elapsed <= 0) ReturnToPool();
    }

    public virtual void ReturnToPool()
    {
        if (returnPool == null)
        {
            Destroy(this.gameObject);
            return;
        }
        returnPool.ReturnToPool(this);
    }
}
