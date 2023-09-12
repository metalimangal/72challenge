using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    private AudioSource audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(bool play)
    {
        if (play)
        {
            if (!audio.isPlaying)
                audio.Play();
        }
        else   
        {
            if (audio.isPlaying)
                audio.Stop();
        }
                
    }
}
