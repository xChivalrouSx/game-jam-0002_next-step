using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button settingButton;
    [SerializeField] GameObject settingUI;

    void Awake()
    {
        settingUI.SetActive(false);

        playButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.Level1);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        settingButton.onClick.AddListener(() =>
        {
            settingUI.SetActive(true);
        });
    }
}
