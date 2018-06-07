using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float Speed = 0;

    [SerializeField]
    Vector3 _direction = Vector3.up;

    //Just for pseudo baloon movement
    [SerializeField, Range(0,1)]
    float _noizeAmount = 0;

    void Update()
    {
        Move(Speed);
    }

    void Move(float speed)
    {
        Vector3 direction = _direction;
        direction.x = (0.5f - Mathf.PerlinNoise(Time.time, 0)) * _noizeAmount;
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}
