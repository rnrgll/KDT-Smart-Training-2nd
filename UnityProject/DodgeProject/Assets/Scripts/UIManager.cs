using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Slider hpSlider;
    
    public void ShowStartUI()
    {
        startPanel.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void UpdateHp(int hp)
    {
        hpSlider.value = hp;
    }

    public void InitHpUI(int maxHp)
    {
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }

    
    
}
