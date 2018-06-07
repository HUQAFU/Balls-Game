using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets random object size OnEnable
/// Author: Adik
/// </summary>
public class SizeController : MonoBehaviour
{
    /// <summary>
    /// Minimum object size
    /// </summary>
    [SerializeField]
    float _minSize = 1f;

    /// <summary>
    /// Maximum object size
    /// </summary>
    [SerializeField]
    float _maxSize = 5f;

    /// <summary>
    /// Calculated scale
    /// </summary>
    float _size;

    /// <summary>
    /// Object to scale
    /// </summary>
    [SerializeField]
    Transform _scalingObject;

    /// <summary>
    /// Get size in percent (_minSize = 0, _maxSize = 1)
    /// </summary>
    public float SizeInPercent
    {
        get
        {
            return Mathf.InverseLerp(_minSize, _maxSize, _size);
        }
    }

    void OnEnable()
    {
        SetSize();
    }

    /// <summary>
    /// Set object size
    /// </summary>
    void SetSize()
    {
        _size = Random.Range(_minSize, _maxSize);
        _scalingObject.localScale = new Vector3(_size, _size, _size);
    }
}
