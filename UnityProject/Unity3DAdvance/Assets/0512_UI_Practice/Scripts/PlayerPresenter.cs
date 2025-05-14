using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPresenter : MonoBehaviour
{
    //모델
    [Header("Model")] 
    [SerializeField] private PlayerData playerData;

    
    
    //뷰
    [Header("View")]
    [SerializeField] private TMP_Text jumpCnt_Txt;
    [SerializeField] private TMP_Text curHp_Txt;
    [SerializeField] private TMP_Text maxHp_Txt;
    [SerializeField] private Slider hpSlider;
    
    //연결
    private void OnEnable()
    {
        playerData.OnJump += SetJumpCnt;
        playerData.OnHpChanged += SetHp;
        playerData.OnMaxHpChanged += SetMaxHp;
    }


    private void OnDisable()
    {
        playerData.OnJump -= SetJumpCnt;
        playerData.OnHpChanged -= SetHp;
        playerData.OnMaxHpChanged -= SetMaxHp;
    }

    private void Start()
    {
        SetMaxHp(playerData.MaxHp);
        SetHp(playerData.Hp);
        SetJumpCnt(playerData.JumpCnt);
    }


    //ui update
    void SetJumpCnt(int cnt)
    {
        jumpCnt_Txt.text = cnt.ToString();
    }

    void SetHp(int hp)
    {
        hpSlider.value = hp;
        curHp_Txt.text = hp.ToString();
    }

    void SetMaxHp(int maxHp)
    {
        hpSlider.maxValue = maxHp;
        maxHp_Txt.text = maxHp.ToString();
    }
}
