using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyUISwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject _menu;

    [SerializeField]
    GameObject _gameScreen;

    [SerializeField]
    GameObject _gameOverScreen;

    // Use this for initialization
    void OnEnable()
    {
        GameManager.GameStarted += OnGameStarted;
        GameManager.GameOvered += OnGameOver;
        GameManager.Menu += OnMenu;
        OnMenu();
    }

    // Update is called once per frame
    void OnGameStarted()
    {
        _menu.SetActive(false);
        _gameOverScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }

    void OnGameOver()
    {
        _menu.SetActive(false);
        _gameOverScreen.SetActive(true);
        _gameScreen.SetActive(false);
    }

    void OnMenu()
    {
        _menu.SetActive(true);
        _gameOverScreen.SetActive(false);
        _gameScreen.SetActive(false);
    }
}
