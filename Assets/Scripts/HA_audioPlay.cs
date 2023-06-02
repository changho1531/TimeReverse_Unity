using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HA_audioPlay : MonoBehaviour
    //말봉코드_heryu(티스토리) Unity - 사운드 조절하기 - Slider로 조절
{
    public AudioMixer masterMixer;
    public Slider bgmSlider;

    public void AudioControl()
    {
        float sound = bgmSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
