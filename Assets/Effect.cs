using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dumme Effect Manager
[RequireComponent(typeof(Ball))]
public class Effect : MonoBehaviour {
    [SerializeField]
    GameObject _popEffectPrefab;
    Ball _ball;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    void OnEnable()
    {
        _ball.BallTaped += OnBallTaped;
    }

    void OnDisable()
    {
        _ball.BallTaped -= OnBallTaped;
    }

    void OnBallTaped(GameObject ball)
    {
        if (_popEffectPrefab) {
            Instantiate(_popEffectPrefab, ball.transform.position, ball.transform.rotation);
        }
    }
}
