using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance
    {
        get;
        private set;
    }

    public event Action OnFinish;
    private bool isFinish;
    public  bool IsFinish
    {
        get => isFinish;
        set
        {
            if (value)
            {
                OnFinish?.Invoke();
            }

            isFinish = value;
        }
    }


    [SerializeField] private GameObject UI_Start;
    [SerializeField] private GameObject UI_Finish;




    [SerializeField] private float gravityScale;
    
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        
        
        
        //월드 중력 세게 적용하기
        Physics.gravity = new Vector3(0, gravityScale, 0);
        Debug.Log(Physics.gravity);

    }

    // Start is called before the first frame update
    void Start()
    {
        isFinish = false;
        OnFinish += FinishGame;
        
        
        Time.timeScale = 0f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FinishGame()
    {
        UI_Finish.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }


    public void StartGame()
    {
        UI_Start.SetActive(false);
        Time.timeScale = 1f;
    }
}
