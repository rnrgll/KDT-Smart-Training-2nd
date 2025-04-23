using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Control")]
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;
    private float h;
    private float v;
    private Vector3 moveDir;
    
    public int Hp
    {
        get => hp;
        private set
        {
            hp = Mathf.Max(0, value); // 절대로 0 미만 안 되게!

            OnHpChanged?.Invoke(hp); // UI 업데이트 먼저 호출

            if (hp <= 0)
            {
                OnDie?.Invoke(); // 죽었을 때만 호출
            }
            
        }
    }

    public int MaxHp => maxHp;
    
    public event Action OnDie;
    public event Action<int> OnHpChanged; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hp = maxHp;
    }


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.InitHpUI(MaxHp);
        OnHpChanged += GameManager.Instance.UpdateHpUI;
        OnDie += GameManager.Instance.GameOver;
    
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //입력은 input으로 받기 -> update에서 처리
    private void GetInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(h, 0, v).normalized;
    }
    
    //플레이어 이동
    private void Move()
    {
        //transform으로 위치 직접 바꾸면? 충돌 처리를 못 하거나, 중첩돼버리거나, 트리거만 동작하고 실제 반응은 안 하는 문제
        //transform.Translate(moveDir * moveSpeed);
        
        //rigidbody 이용하자
        rb.velocity = moveDir * moveSpeed;
    }

    public void OnAttacked(int damage)
    {
        Hp -= damage;
    }
}
