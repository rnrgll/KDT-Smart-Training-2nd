using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private UIManager uiManager;
    
    #region UI

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePanel;
    
    [SerializeField] private Slider _slider;
    
    
    
    #endregion
    
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            if (go == null)
            {
                //생성
                go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(go);
            Instance = go.GetComponent<GameManager>();
            
        }

    }

    private void Start()
    {
        Time.timeScale = 0f;
        startPanel.SetActive(true);
    }


    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        Time.timeScale = 0;
    }


    public void UpdateHpUI(int hp)
    {
        _slider.value = hp;
    }

    public void InitHpUI(int maxHp)
    {
        
        _slider.maxValue = maxHp;
        _slider.value = maxHp;
    }
}

