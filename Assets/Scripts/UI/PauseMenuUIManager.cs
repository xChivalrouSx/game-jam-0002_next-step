using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUIManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] GameObject pauseScreen;


    private void Awake()
    {
        pauseScreen.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    #region Pause
    private void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        Time.timeScale = status ? 0 : 1;
    }
    #endregion

    public void Resume()
    {
        PauseGame(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == Loader.Scene.Level1.ToString())
            Destroy(gameObject);
        else
            PauseGame(false);
        
        
    }

    public void SoundVolume()
    {
        AudioManager.Instance?.SfxVolume(0.2f);
        Debug.Log("Ahoa");
    }

    public void MusicVolume()
    {
        AudioManager.Instance?.MusicVolume(0.2f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
