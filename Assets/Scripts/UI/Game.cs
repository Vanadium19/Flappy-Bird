using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Awake()
    {
        _startScreen.Open();
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _startScreen.StartButtonClicked += OnStartButtonClick;
        _gameOverScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.Died += GameOver;
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClicked -= OnStartButtonClick;
        _gameOverScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.Died -= GameOver;
    }

    private void OnStartButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _spawner.ResetSpawner();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetBird();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
