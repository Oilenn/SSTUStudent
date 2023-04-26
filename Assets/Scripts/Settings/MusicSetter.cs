using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _masterSlider;

    private void Start()
    {
        OnChangeMaster();
        OnChangeMusic();
        OnChangeSound();
    }

    public void OnChangeMaster()
    {
        _mixer.SetFloat("MasterVolume", -80 + (_masterSlider.value * 80));
    }

    public void OnChangeMusic()
    {
        _mixer.SetFloat("MusicVolume", -80 + (_musicSlider.value * 80));
    }

    public void OnChangeSound()
    {
        _mixer.SetFloat("SoundVolume", -80 + (_soundSlider.value * 80));
    }
}
