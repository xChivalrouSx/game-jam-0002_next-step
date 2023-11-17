using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Button closeButton;


    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSfxVolume);
        closeButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        this.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Music");
            musicSlider.value = savedVolume;
        }
        if (PlayerPrefs.HasKey("Sfx"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Sfx");
            sfxSlider.value = savedVolume;
        }
    }

    private void ChangeMusicVolume(float volume)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.musicSource.volume = volume;
        }
        PlayerPrefs.SetFloat("Music", volume);
        PlayerPrefs.Save();
    }

    private void ChangeSfxVolume(float volume)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.soundSource.volume = volume;
        }
        PlayerPrefs.SetFloat("Sfx", volume);
        PlayerPrefs.Save();
    }
}
