using System.Collections;
using UnityEngine;
using System;

/// <summary>
/// Custom timer class that counts time and send events on End and Stopped
/// Author: Adik
/// </summary>
public class CustomTimer
{
    /// <summary>
    /// this is just for using courutines without inheritance from MonoBehaviour...
    /// </summary>
    public MonoBehaviour ParentMonoBehavior;

    /// <summary>
    /// Current timer coroutine
    /// </summary>
    Coroutine _timer;

    /// <summary>
    /// Time to count
    /// </summary>
    public float Time { get; protected set; }

    /// <summary>
    /// Current counted time
    /// </summary>
    public float CurrentTime { get; protected set; }

    /// <summary>
    /// Count ended event
    /// </summary>
    public event Action End;

    /// <summary>
    /// Timer forced to stop event
    /// </summary>
    public event Action Stopped;

    /// <summary>
    /// Time left event - for UI and etc...
    /// </summary>
    public event Action<float> TimeLeftUpdated;

    /// <summary>
    /// Starts timer to count specified time
    /// </summary>
    /// <param name="monoBehavior"></param>
    /// <param name="time">Time to count</param>
    public void StartTimer(MonoBehaviour monoBehavior, float time)
    {
        CurrentTime = 0;
        ParentMonoBehavior = monoBehavior;
        Time = time;
        ParentMonoBehavior.StartCoroutine(CountTime());
    }

    /// <summary>
    /// Stop timer
    /// </summary>
    public void Stop() {
        ParentMonoBehavior.StopAllCoroutines();
        Stopped?.Invoke();
    }


    /// <summary>
    /// Count timer, adn send event on end of count
    /// </summary>
    /// <returns></returns>
    IEnumerator CountTime()
    {
        while (CurrentTime < Time)
        {
            CurrentTime += UnityEngine.Time.deltaTime;
            TimeLeftUpdated?.Invoke(Time - CurrentTime);
            yield return new WaitForEndOfFrame();
            
        }
        End?.Invoke();
    }
}



