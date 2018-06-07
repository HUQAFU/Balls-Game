using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// Sends game events to components
/// Author: Adik
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Calls on game start
    /// </summary>
    public static event Action GameStarted;

    /// <summary>
    /// Calls on game over
    /// </summary>
    public static event Action GameOvered;

    /// <summary>
    /// Calls on back to menu
    /// </summary>
    public static event Action Menu;


    /// <summary>
    /// Send GameStarted event
    /// </summary>
    public static void StartGame()
    {
        GameStarted?.Invoke();
    }

    /// <summary>
    /// Send GameOvered event
    /// </summary>
    public static void GameOver()
    {
        GameOvered?.Invoke();
    }

    /// <summary>
    /// Send Menu event
    /// </summary>
    public static void BackToMenu()
    {
        Menu?.Invoke();
    }

    /// <summary>
    /// call StartGame for dummy UI
    /// </summary>
    public void CallStartGame()
    {
        StartGame();
    }

    /// <summary>
    /// call BackToMenu for dummy UI
    /// </summary>
    public void CallBackToMenu()
    {
        BackToMenu();
    }

}
