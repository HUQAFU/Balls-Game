using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moves object by Speed to _direction
/// Author: Adik
/// </summary>
public class Motor : MonoBehaviour
{
    /// <summary>
    /// Movement speed
    /// </summary>
    public float Speed = 0;

    /// <summary>
    /// Direction of movement
    /// </summary>
    [SerializeField]
    Vector3 _direction = Vector3.up;

    /// <summary>
    /// Movement noize amount - just for pseudo baloon movement
    /// </summary>
    [SerializeField, Range(0, 1)]
    float _noizeAmount = 0;

    void Update()
    {
        Move(Speed);
    }

    /// <summary>
    /// Move object by Speed to _direction
    /// </summary>
    /// <param name="speed">Movement speed</param>
    void Move(float speed)
    {
        Vector3 direction = _direction;
        direction.x = (0.5f - Mathf.PerlinNoise(Time.time, 0)) * _noizeAmount;
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}