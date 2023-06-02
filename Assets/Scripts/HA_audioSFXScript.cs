using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HA_audioSFXScript : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider bgmSlider;

    public void AudioControl()
    {
        float sound = bgmSlider.value;

        if (sound == -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
