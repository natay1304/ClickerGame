using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource Sound;
    public AudioSource Music;

    [SerializeField]
    private ToggleController _toggleMusic;
    [SerializeField]
    private ToggleController _toggleSound;

    private void Start()
    {
        _toggleMusic.OnValueChanged += _toggleMusic_OnValueChanged;
        _toggleSound.OnValueChanged += _toggleSound_OnValueChanged;

        _toggleSound.SetValue(true);
        _toggleMusic.SetValue(true);
    }

    private void _toggleSound_OnValueChanged(bool value)
    {
        Sound.mute = !value;
    }

    private void _toggleMusic_OnValueChanged(bool value)
    {
        Music.mute = !value;
    }
}
