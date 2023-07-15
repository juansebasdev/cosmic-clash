using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : SoundManager
{
    public static SFXManager Instance { get; private set; }
    [SerializeField] AudioClip _uiClick;
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

        _audioSource.loop = false;
        _volume = _audioSource.volume;
    }

    public void PlayUIClick()
    {
        PlayClip(_uiClick);
    }

    private void PlayClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
