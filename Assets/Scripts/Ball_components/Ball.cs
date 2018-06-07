using UnityEngine;
using System;

/// <summary>
/// Sends Ball events to components
/// Author: Adik
/// </summary>
public class Ball : MonoBehaviour
{
    /// <summary>
    /// Calls when user taps on ball
    /// </summary>
    public event Action<GameObject> BallTaped;

    /// <summary>
    /// Calls when Ball flew away from screen (for destroy)
    /// </summary>
    public event Action<GameObject> BallFlewAway;

    /// <summary>
    /// link to flew away check component
    /// </summary>
    FlewAwayChecker _flewAwaychecker;

    private void Awake()
    {
        _flewAwaychecker = GetComponentInChildren<FlewAwayChecker>();
    }

    private void OnEnable()
    {
        if (_flewAwaychecker)
        {
            _flewAwaychecker.BecameInvisible += OnFlewAway;
        }
    }

    private void OnDisable()
    {
        if (_flewAwaychecker)
        {
            _flewAwaychecker.BecameInvisible -= OnFlewAway;
        }
    }

    /// <summary>
    /// Send BallTaped event
    /// </summary>
    public void OnTap()
    {
        BallTaped?.Invoke(gameObject);
    }

    /// <summary>
    /// Send flew away event
    /// </summary>
    public void OnFlewAway()
    {
        BallFlewAway?.Invoke(gameObject);
    }
}
