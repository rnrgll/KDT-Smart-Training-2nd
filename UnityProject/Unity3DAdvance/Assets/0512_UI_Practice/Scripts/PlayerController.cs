using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData; //model
    
    
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private bool isJump = false;
    [SerializeField] private float  rayLength = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerData = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        HpControl();
        
    }
    
    
    //바닥 체크
    private void GroundCheck()
    {
        //발바닥 위치
        Vector3 footPos = new Vector3(
            capsuleCollider.bounds.center.x, 
            capsuleCollider.bounds.min.y + 0.05f,
            capsuleCollider.bounds.center.z);
        // Vector3 footPos = capsuleCollider.bounds.min + Vector3.up * 0.05f;
        
        
        //ray를 아래로 발사
        Ray ray = new Ray(footPos, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength, groundLayer))
        {
            if (isJump)
            {
                isJump = false;
                Debug.Log("착지");
            }
        }
        else
        {
            //공중에 있는 상태
            if (!isJump)
            {
                isJump = true;
            }
        }
        
        Debug.DrawRay(footPos,Vector3.down*rayLength,Color.green);
    }
    
    
    //점프
    private void Jump()
    {
        GroundCheck();
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            //수직 속도 초기화
            rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
            
            //위로점프
            rigid.AddForce(Vector3.up*jumpSpeed, ForceMode.VelocityChange);

            playerData.JumpCnt += 1;
            Debug.Log("Jump!");

        }
    }

    private void HpControl()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerData.Hp += 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerData.Hp -= 1;
        }
    }
}
