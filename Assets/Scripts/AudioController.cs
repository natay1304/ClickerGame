using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource Sound;
    public AudioSource Music;

    [SerializeField]
    private ToggleController _toggleMusic;
    [SerializeField]
    private ToggleController _toggleSound;
    [SerializeField]
    private Button _soundPanelButton;
    [SerializeField]
    private GameObject _soundPanel;

    private void Start()
    {

        if (!PlayerPrefs.HasKey("Sound"))
            PlayerPrefs.SetInt("Sound", 0);

        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetInt("Music", 0);

        Sound.mute = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
        Music.mute = PlayerPrefs.GetInt("Music") == 1 ? true : false;

        _toggleMusic.SetValue(!Music.mute);
        _toggleSound.SetValue(!Sound.mute);
        
        _toggleMusic.OnValueChanged += MusicValueChangedHandler;
        _toggleSound.OnValueChanged += SoundValueChangedHandler;

        _soundPanelButton.onClick.AddListener(SoundPanelHandler);

    }

    private void SoundPanelHandler()
    {
        _soundPanel.SetActive(true);
    }

    private void SoundValueChangedHandler(bool value)
    {
        Sound.mute = !value;
        PlayerPrefs.SetInt("Sound", value ? 0 : 1);
    }

    private void MusicValueChangedHandler(bool value)
    {
        Music.mute = !value;
        PlayerPrefs.SetInt("Music", value ? 0 : 1);
    }
}
