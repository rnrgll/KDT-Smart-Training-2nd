using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseStat : MonoBehaviour, IDamagable
{
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected int attack;


    public int Hp
    {
        get => hp;
        protected set
        {
            if (value <= 0)
            {
                hp = 0;
                OnDead();
                return;
            }

            hp = value;
            OnHpChanged?.Invoke(hp);
        }
    }

    public int MaxHp => maxHp;
    public int Attack => attack;

    public event UnityAction<int> OnHpChanged;

    private void Awake()
    {
        OnHpChanged = null;
    }

    private void Start()
    {
        Init();
        
    }

    protected virtual void Init()
    {
        Hp = MaxHp;
    }
    
    protected virtual void OnDead()
    {
        Debug.Log($"{gameObject.name} 사망!");
        
        //스코어 증가
        GameManager.Instance.AddScore(1);
        
        EffectPool.Instance.GetPoolObject(transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    public void TakeDamage(GameObject attacker, int damage)
    {
        Hp -= damage;
    }
}
