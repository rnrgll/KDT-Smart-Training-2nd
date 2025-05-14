using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;
    private int _highScore = 0;
    private bool _isGameOver = false;

    public int Score => _score;

    public int HighScore => _highScore;
   
    public bool IsGameOver => _isGameOver;

    public GameObject gameOverUI;


    public UnityEvent<int> OnUpdateScore;
    public UnityEvent<int> OnUpdateHighScore;
    
    private void Start()
    {
        _score = 0;
        _highScore = 0;
        _isGameOver = false;
        gameOverUI.SetActive(false);
    }
    
    private void Update()
    {
        
        if (_isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    
    public void AddScore(int amount)
    {
        if (_isGameOver) return;

        _score += amount;
        OnUpdateScore?.Invoke(_score);
        if (_score > _highScore)
        {
            _highScore = _score;
            OnUpdateHighScore?.Invoke(_highScore);
        }
    }

    
    public void GameOver()
    {
        _isGameOver = true;
        gameOverUI.SetActive(true);
       
    }
    
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}