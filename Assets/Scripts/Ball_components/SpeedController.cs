using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes Motor speed by Size in SizeController
/// Author: Adik
/// </summary>
[RequireComponent(typeof(SizeController), typeof(Motor))]
public class SpeedController : MonoBehaviour
{
    /// <summary>
    /// Minimum balls speed (size - maximum)
    /// </summary>
    [SerializeField]
    float _minSpeed = 1;
    /// <summary>
    /// Maximum balls speed (size - minimum)
    /// </summary>
    [SerializeField]
    float _maxSpeedr = 5;

    /// <summary>
    /// Links to controllers
    /// </summary>
    Motor _motor;
    SizeController _sizeController;

    /// <summary>
    /// Calculated base speed
    /// </summary>
    float _baseSpeed;

    private void Awake()
    {
        _motor = GetComponent<Motor>();
        _sizeController = GetComponent<SizeController>();
    }

    void Start()
    {
        SetBaseSpeed();
        SetMotorSpeed();
    }

    /// <summary>
    /// Set calculated base speed
    /// </summary>
    void SetBaseSpeed()
    {
        _baseSpeed = Mathf.Lerp(_minSpeed, _maxSpeedr, 1 - _sizeController.SizeInPercent);
    }

    /// <summary>
    /// Set motor speed
    /// </summary>
    void SetMotorSpeed()
    {
        _motor.Speed = _baseSpeed;
    }
}

