using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundManager : MonoBehaviour, ISoundManager
{
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected GameObject _soundButton;
    protected SoundBtn _soundBtn;
    protected float _volume;
    protected float _lastVolume = 0;

    public void SetVolume(float volume)
    {
        _volume = volume;
        _audioSource.volume = _volume;
        if (_audioSource.volume != 0) _lastVolume = _audioSource.volume;
        _soundBtn.ChangeSound();
    }

    public float GetVolume()
    {
        return _volume;
    }

    public void Sound()
    {
        if (_lastVolume < 0.05) _lastVolume = 1;
        if (GameManager.Instance.hasSound) SetVolume(_lastVolume);
        else SetVolume(0);
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
