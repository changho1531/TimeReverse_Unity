using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicsource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //오디오 소스 볼륨 조절
    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }
}
