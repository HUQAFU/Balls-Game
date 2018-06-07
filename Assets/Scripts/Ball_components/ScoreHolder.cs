using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Stores balls score
/// Author: Adik
/// </summary>
[RequireComponent(typeof(Ball))]
public class ScoreHolder : MonoBehaviour
{
    /// <summary>
    /// Score earned event (on ball taped)
    /// </summary>
    public static event Action<int> ScoreEarned;

    /// <summary>
    /// Min score value when max balls size
    /// </summary>
    [SerializeField]
    public int _minSizeScore = 1;

    /// <summary>
    /// Max score value when min balls size
    /// </summary>
    [SerializeField]
    public int _maxSizeScore = 5;

    /// <summary>
    /// Calculated score
    /// </summary>
    int _score;
    
    /// <summary>
    /// Linked Ball
    /// </summary>
    Ball _ball;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    void OnEnable()
    {
        _ball.BallTaped += OnBallTaped;
    }

    /// <summary>
    /// Set calculated score
    /// </summary>
    private void Start()
    {
        SizeController sizeController = GetComponent<SizeController>();
        _score = (int)Mathf.Lerp(_minSizeScore, _maxSizeScore, 1 - sizeController.SizeInPercent);
    }

    void OnDisable()
    {
        _ball.BallTaped -= OnBallTaped;
    }

    /// <summary>
    /// Call ScoreEarned event on ball taped
    /// </summary>
    /// <param name="ball">Ball</param>
    void OnBallTaped(GameObject ball)
    {
         ScoreEarned?.Invoke(_score);
    }
}
