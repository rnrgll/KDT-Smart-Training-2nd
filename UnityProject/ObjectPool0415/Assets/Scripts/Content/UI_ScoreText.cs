using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScoreTxt;
    [SerializeField] private TMP_Text _scoreTxt;
    

    private void OnEnable()
    {
        GameManager.Instance.OnUpdateScore.AddListener(UpdateScore);
        GameManager.Instance.OnUpdateHighScore.AddListener(UpdateHighScore);
        UpdateScore(GameManager.Instance.Score);
        UpdateHighScore(GameManager.Instance.HighScore);
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnUpdateScore.RemoveListener(UpdateScore);
            GameManager.Instance.OnUpdateHighScore.RemoveListener(UpdateHighScore);
        }
    }

    private void UpdateScore(int score)
    {
        _scoreTxt.text = $"Score : {score}";
    }

    private void UpdateHighScore(int highScore)
    {
        _highScoreTxt.text = $"HighScore : {highScore}";
    }
    
}
