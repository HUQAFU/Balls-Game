using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys ball
/// Author: Adik
/// </summary>
[RequireComponent(typeof(Ball))]
public class BallDestroyer : MonoBehaviour
{
    /// <summary>
    /// Current linked Ball
    /// </summary>
    Ball _ball;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    void OnEnable()
    {
        GameManager.GameOvered += OnGameOver;
        _ball.BallTaped += DestroyBall;
        _ball.BallFlewAway += DestroyBall;
    }

    void OnDisable()
    {
        GameManager.GameOvered -= OnGameOver;
        _ball.BallTaped -= DestroyBall;
        _ball.BallFlewAway += DestroyBall;
    }

    /// <summary>
    /// Call DestroyBall on game over
    /// </summary>
    void OnGameOver()
    {
        DestroyBall(_ball.gameObject);
    }

    /// <summary>
    /// Perform Destroy
    /// </summary>
    /// <param name="ball">Ball's GameObject to destroy</param>
    void DestroyBall(GameObject ball)
    {
        //Destroy, send to pool and etc
        Destroy(ball);
    }
}
