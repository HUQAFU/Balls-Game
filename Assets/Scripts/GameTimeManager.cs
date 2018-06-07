using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages time of game
/// Author: Adik
/// </summary>
public class GameTimeManager : MonoBehaviour {
    /// <summary>
    /// Public game Timer (for update UI purpose and etc.)
    /// </summary>
    public static CustomTimer GameTimer = new CustomTimer();

    /// <summary>
    /// Duration of game session
    /// </summary>
    [SerializeField]
    float _gameTime = 60;

    private void OnEnable()
    {
        GameManager.GameStarted += OnStartGame;
        GameManager.GameOvered += OnGameOver;
        GameTimer.End += OnTimerEnd;
    }

    private void OnDisable()
    {
        GameManager.GameStarted -= OnStartGame;
        GameManager.GameOvered -= OnGameOver;
        GameTimer.End -= OnTimerEnd;
    }

    /// <summary>
    /// Start timer with _gameTime
    /// </summary>
    void OnStartGame() {
        GameTimer.StartTimer(this, _gameTime);
    }

    /// <summary>
    /// Stop timer on GameOver
    /// </summary>
    void OnGameOver()
    {
        GameTimer.Stop();
    }

    /// <summary>
    /// Call GameOver on Timer.End
    /// </summary>
    void OnTimerEnd() {
        GameManager.GameOver();
    }
}
