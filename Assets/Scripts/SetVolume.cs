using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer effectMixer;
    public void SetMusicLevel(float musicSliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(musicSliderValue) * 20);
    }
    public void SetSFXLevel(float effectSliderValue)
    {
        effectMixer.SetFloat("EffectVolume", Mathf.Log10(effectSliderValue) * 20);
    }
}
