using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Controls;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Back();
        }
    }
        
    public void Play()
    {
        Loader.Load(Loader.Scene.Level1);
    }

    public void SoundVolume()
    {
        AudioManager.Instance?.SfxVolume(0.2f);
    }

    public void MusicVolume()
    {
        AudioManager.Instance?.MusicVolume(0.2f);
    }

    public void Credits()
    {

    }
    public void ControlMenu()
    {
        MainMenu.SetActive(false);
        Controls.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        Controls.SetActive(false);
    }


}
