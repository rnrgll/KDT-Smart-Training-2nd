using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScoreTxt;
    [SerializeField] private TMP_Text _scoreTxt;

    private void Awake()
    {
        GameManager.Instance.OnUpdateScore.AddListener(UpdateScore);
        GameManager.Instance.OnUpdateHighScore.AddListener(UpdateHighScore);

    }

    private void UpdateScore(int score)
    {
        _scoreTxt.text = $"Score : {score}";
    }

    private void UpdateHighScore(int highScore)
    {
        _highScoreTxt.text = $"HighScore : {highScore}";
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnUpdateScore.RemoveListener(UpdateScore);
        GameManager.Instance.OnUpdateHighScore.RemoveListener(UpdateHighScore);

    }
}
