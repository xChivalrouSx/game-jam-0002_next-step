using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUIManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject controls;
    [SerializeField] GameObject dayInfoCanvas;
    private bool controlScreen = false;

    private void Awake()
    {
        pauseScreen.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!controlScreen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame(!pauseScreen.activeInHierarchy);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
            {

                controls.SetActive(false);
                pauseScreen.SetActive(true);
            }
        }
    }

    #region Pause
    private void PauseGame(bool status)
    {
        dayInfoCanvas.SetActive(!dayInfoCanvas.active);
        pauseScreen.SetActive(status);
        Time.timeScale = status ? 0 : 1;
    }
    #endregion

    public void Resume()
    {
        PauseGame(false);
    }
    public void ControlMenu()
    {
        controls.SetActive(true);
        pauseScreen.SetActive(false);
        controlScreen = true;
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
    public void Back()
    {
        pauseScreen.SetActive(true);
        controls.SetActive(false);
        controlScreen = false;
    }

}
