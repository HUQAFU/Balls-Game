using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns random prefab from _prefabs in _spawnRange with _spawnInterval
/// Author Adik:
/// </summary>
public class BallSpawner : MonoBehaviour
{
    /// <summary>
    /// prefabs for spawning
    /// </summary>
    [SerializeField]
    GameObject[] _prefabs;

    /// <summary>
    /// X range of spawn
    /// </summary>
    [SerializeField]
    float _spawnXRange = 3;

    /// <summary>
    /// interval of spawning prefabs
    /// </summary>
    [SerializeField]
    float _spawnInterval = 1;

    private void OnEnable()
    {
        GameManager.GameStarted += OnStartGame;
        GameManager.GameOvered += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.GameStarted -= OnStartGame;
        GameManager.GameOvered -= OnGameOver;
    }

    /// <summary>
    /// Start spawning
    /// </summary>
    void OnStartGame()
    {
        if (_prefabs != null && _prefabs.Length > 0)
        {
            InvokeRepeating("Spawn", 0, _spawnInterval);
        }
        else
        {
            Debug.LogAssertion("There is no prefabs in _prefabs!", this);
        }
    }

    /// <summary>
    /// Stop spawning
    /// </summary>
    void OnGameOver()
    {
        CancelInvoke();
    }

    /// <summary>
    /// Perform spawn
    /// </summary>
    void Spawn()
    {
        GameObject Ball = _prefabs[Random.Range(0, _prefabs.Length)];
        if (Ball)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-_spawnXRange, _spawnXRange), transform.position.y, transform.position.z);
            Instantiate(Ball, spawnPosition, transform.rotation);
        }
        else {
            Debug.LogAssertion("Null element in Prefabs array?", this);
        }

    }
}
