using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private StartScreen _startSreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private OptionsScreen _optionsScreen;

    private void OnEnable()
    {
        _startSreen.PlayButtonClick += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _optionsScreen.OptionsButtonClick += OnOptionsButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startSreen.PlayButtonClick -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _optionsScreen.OptionsButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startSreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startSreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }

    private void OnOptionsButtonClick()
    {
        Time.timeScale = 0;
        _optionsScreen.Open();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _mover.SetStartSpeed();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }
}
