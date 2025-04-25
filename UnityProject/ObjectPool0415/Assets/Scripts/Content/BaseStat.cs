using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseStat : MonoBehaviour
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
    
    
    

    public virtual void OnAttacked(BaseStat attacker)
    {
        Hp -= attacker.Attack;
    }
    
    public virtual void OnAttacked(int damage)
    {
        
        Hp -= damage;

    }


    protected virtual void OnDead()
    {
        Debug.Log($"{gameObject.name} 사망!");
        EffectPool.Instance.GetPoolObject(transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    

}
