using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _cangeDirectionSound;
    [SerializeField] private ParticleSystem _plusSpeed;

    private AudioSource _audioSource;

    private bool _isMove;
    private const float _maxSpeed = 200f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartGame();
    }

    private void Update()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (_isMove == true)
            ChooseDirection(_speed);
        else
            ChooseDirection(-_speed);
    }

    private void ChooseDirection(float speed)
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public void OnClickScreen()
    {
        float minPitch = 0.9f;
        float maxPitch = 1.1f;

        _audioSource.pitch = Random.Range(minPitch, maxPitch);
        _audioSource.Play();
        _isMove = !_isMove;
    }

    private IEnumerator ScoreReachedValue()
    {
        var WaitForSeconds = new WaitForSeconds(10f);
        yield return WaitForSeconds;

        if (_speed < _maxSpeed)
        {
            _speed += 5;
            Instantiate(_plusSpeed, transform.position, Quaternion.identity);
            StartCoroutine(ScoreReachedValue());
        }
    }

    public void StartGame()
    {
        _speed = 120f;
        StartCoroutine(ScoreReachedValue());
    }
}
