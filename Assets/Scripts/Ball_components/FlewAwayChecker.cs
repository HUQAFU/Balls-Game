using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Checks that object is out of screen
/// Author: Adik
/// </summary>
public class FlewAwayChecker : MonoBehaviour
{
    /// <summary>
    /// Out of screen event
    /// </summary>
    public event Action BecameInvisible;

    /// <summary>
    /// Send BecameInvisible event when object BecameInvisible (out of screen)
    /// </summary>
    void OnBecameInvisible()
    {
        BecameInvisible?.Invoke();
    }
}
