using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class OptionsScreen : Screen
{
    [SerializeField] private Slider _volume;
    [SerializeField] private AudioSource _audioSource;
    
    private float _soundVolume = 1f;
    
    public event UnityAction OptionsButtonClick;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _soundVolume;
    }

    public void SetVolume(float volume)
    {
        _soundVolume = volume;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Time.timeScale = 1;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected override void OnButtonClick()
    {
        OptionsButtonClick?.Invoke();
    }
}
