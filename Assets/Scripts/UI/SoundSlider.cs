using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private string _nameOfAudioObject;
    [SerializeField]private Slider _slider;
    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = GameObject.Find(_nameOfAudioObject).GetComponent<SoundManager>();
        _slider.value = _soundManager.GetVolume();

        _slider.onValueChanged.AddListener(x => SetVolume(x));
    }

    private void SetVolume(float volumeValue)
    {
        _soundManager.SetVolume(volumeValue);
    }

    public void SetVolumeOnSlider()
    {
        _soundManager = GameObject.Find(_nameOfAudioObject).GetComponent<SoundManager>();
        _slider.value = _soundManager.GetVolume();
    }
}
