using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBtn : MonoBehaviour
{
    [SerializeField] private GameObject _mute;
    [SerializeField] private GameObject _sound;
    private bool _showMute = true;

    private void Start()
    {
        _showMute = AudioManager.Instance.GetVolume() != 0 || SFXManager.Instance.GetVolume() != 0;
        UpdateStateOnScreen();
    }

    public void ChangeSound()
    {
        _showMute = AudioManager.Instance.GetVolume() != 0 || SFXManager.Instance.GetVolume() != 0;
        UpdateStateOnScreen();
    }

    public void SetHasSound(float volume)
    {
        _showMute = volume == 0 ? false : true;
        UpdateStateOnScreen();
    }

    private void UpdateStateOnScreen()
    {
        _mute.SetActive(_showMute);
        _sound.SetActive(!_showMute);
    }
}
