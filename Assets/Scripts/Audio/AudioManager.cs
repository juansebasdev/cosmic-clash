using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SoundManager
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameplayMusic;
    [SerializeField] private AudioClip _creditsMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _soundBtn = _soundButton.GetComponent<SoundBtn>();
    
        _audioSource.loop = true;
        _volume = _audioSource.volume;
        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        PlayMusic(_menuMusic);
    }

    public void PlayGameplayMusic()
    {
        PlayMusic(_gameplayMusic);
    }

    public void PlayCreditsMusic()
    {
        PlayMusic(_creditsMusic);
    }

    private void PlayMusic(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
