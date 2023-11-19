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
        ChangeSourceVolume(0.3f, "Music", volume, soundSource);
    }
    public void SfxVolume(float volume)
    {
        ChangeSourceVolume(1, "Sfx", volume, soundSource);
    }


    private void ChangeSourceVolume(float baseVolume, string volumeName, float change, AudioSource source)
    {
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;

        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;

        float finalVolume = currentVolume * baseVolume;
        source.volume = finalVolume;

        PlayerPrefs.SetFloat(volumeName, currentVolume);
        PlayerPrefs.Save();
    }

    public void PlayJumpSFX()
    {
        soundSource.PlayOneShot(jumpAudioClip);
    }

    public void PlaySound(AudioClip sound)
    {
        soundSource.PlayOneShot(sound);
    }
}
