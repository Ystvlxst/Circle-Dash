using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private AudioClip _coinUpSound;

    private AudioSource _audioSource;
    private Vector3 _startPosition;
    private const float _positionX = 2.062f;
    private int _score;
    private int _highScore;

    public event UnityAction GameOver;
    public TMP_Text ScoreText => _scoreText;
    public int Score => _score;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Reset();
    }

    private void Update()
    {
        _highScore = _score;
        _scoreText.text = _highScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.TryGetComponent(out Coin coin))
        {
            _score++;
            PlaySound();
            Destroy(coin);
            CheckScoreChange();
        }

        if (other.TryGetComponent(out EnemyMover enemy))
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
        GameOver?.Invoke();
    }

    private void PlaySound()
    {
        float minPitch = 0.9f;
        float maxPitch = 1.1f;

        _audioSource.pitch = Random.Range(minPitch, maxPitch);
        _audioSource.Play();
    }

    public void Reset()
    {
        _startPosition = new Vector3(_positionX, 0, 0);
        gameObject.SetActive(true);
        _score = 0;
    }

    private void CheckScoreChange()
    {
        if (PlayerPrefs.GetInt(ScoreManager.Params.Score) <= _highScore)
            PlayerPrefs.SetInt(ScoreManager.Params.Score, _highScore);

        _highScoreText.text = ScoreManager.Params.HighScore + PlayerPrefs.GetInt(ScoreManager.Params.Score).ToString();
    }
}

public static class ScoreManager
{
    public static class Params
    {
        public const string Score = nameof(Score);
        public const string HighScore = "High Score: ";
    }
}
