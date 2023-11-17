using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundSource;
    public AudioClip jumpAudioClip;
    public static AudioManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.SetFloat("Music", .5f);
        PlayerPrefs.SetFloat("Sfx", .5f);
        PlayerPrefs.Save();
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        soundSource.volume = volume;
    }

    public void PlayJumpSFX()
    {
        soundSource.PlayOneShot(jumpAudioClip);
    }
}
