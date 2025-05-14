using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private CapsuleCollider capsuleCollider;

    [Header("Move")] 
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 150f;
    
    [Header("UI")] 
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameClearPanel;

    
    private bool isDead = false;
    private bool isClear = false;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead || isClear) return;
        
        Move();
        SwitchCCTV();
        
    }
    
 
    //이동
    void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        
        //앞 / 뒤 이동
        Vector3 direction = transform.forward * v;
        rigid.velocity = direction * moveSpeed;
        
        //회전
        transform.Rotate(Vector3.up * rotateSpeed * h * Time.deltaTime);
    }

    public void Die()
    {
        isDead = true;
        Time.timeScale = 0;
        Debug.Log("사망 - 게임 종료");
        gameOverPanel.SetActive(true);
        
    }

    public void GameClear()
    {
        isClear = true;
        Time.timeScale = 0;
        Debug.Log("도착 - 게임 클리어");
        gameClearPanel.SetActive(true);
    }


    public void SwitchCCTV()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
           CCTVManager.Instance.ShowCCTV(1);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            CCTVManager.Instance.ShowCCTV(2);        
        }
        else
        {
            CCTVManager.Instance.HideAllCCTV();
        }
    }
}
