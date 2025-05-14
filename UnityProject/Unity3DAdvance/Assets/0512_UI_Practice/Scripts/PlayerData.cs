using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //hp / max hp
    [SerializeField] private int hp = 100;
    [SerializeField] private int maxHp = 100;
    public int Hp
    {
        get => hp;
        set
        {
            value = Mathf.Clamp(value, 0, maxHp);
            if (hp != value)
            {
                hp = value;
                OnHpChanged?.Invoke(hp);
            }
            
        }
    }

    public int MaxHp
    {
        get => maxHp;
        set
        {
            maxHp = value;
            OnMaxHpChanged?.Invoke(maxHp);
        }
    }

    public event Action<int> OnHpChanged;
    public event Action<int> OnMaxHpChanged;
    
    //jump count
    [SerializeField] private int  jumpCnt = 0;
    public int JumpCnt
    {
        get => jumpCnt;
        set
        {
            jumpCnt = value;
            OnJump?.Invoke(jumpCnt);
        }
    }
    public event Action<int> OnJump;
    
}
