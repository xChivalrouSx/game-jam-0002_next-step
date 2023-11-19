using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    
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

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
