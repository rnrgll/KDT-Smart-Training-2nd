using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    public int MaxHp => maxHp;
    public int Attack => attack;


    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        Hp = MaxHp;
        Debug.Log(Hp);
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
