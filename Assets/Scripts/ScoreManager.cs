using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Manages game score
/// Author: Adik
/// </summary>
public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Ingame score updated event
    /// </summary>
    public static event Action<int> ScoreUpdated;

    /// <summary>
    /// Best score updated event
    /// </summary>
    public static event Action<int> BestScoreUpdated;

    /// <summary>
    /// Current ingame score
    /// </summary>
    static int _currentScore;
    public static int CurrentScore
    {
        get
        {
            return _currentScore;
        }

        set
        {
            _currentScore = value;
            ScoreUpdated?.Invoke(_currentScore);
        }
    }

    /// <summary>
    /// Best player's score
    /// </summary>
    static int _bestScore;
    public static int BestScore
    {
        get
        {
            return _bestScore;
        }
        protected set
        {
            _bestScore = value;
            BestScoreUpdated?.Invoke(_bestScore);
            PlayerPrefs.SetInt("Best Score", BestScore);
        }
    }

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt("Best Score", 0);
    }

    void OnEnable()
    {
        GameManager.GameStarted += OnGameStarted;
        GameManager.GameOvered += OnGameOvered;
    }

    void OnDisable()
    {
        GameManager.GameStarted -= OnGameStarted;
        GameManager.GameOvered -= OnGameOvered;
    }

    /// <summary>
    /// Reset current score and subscribe to ScoreEarned event
    /// </summary>
    void OnGameStarted()
    {
        ScoreHolder.ScoreEarned += AddScore;
        CurrentScore = 0;
    }

    /// <summary>
    /// Check best score and unsubscribe from ScoreEarned event
    /// </summary>
    void OnGameOvered()
    {
        ScoreHolder.ScoreEarned -= AddScore;
        CheckBestScore();
    }

    /// <summary>
    /// Add ingame score
    /// </summary>
    /// <param name="score">score to add</param>
    void AddScore(int score)
    {
        CurrentScore += score;
    }

    /// <summary>
    /// Check if current score better than best player's score - save it
    /// </summary>
    void CheckBestScore()
    {
        if (CurrentScore > BestScore)
        {
            BestScore = CurrentScore;
            
        }
    }
}
