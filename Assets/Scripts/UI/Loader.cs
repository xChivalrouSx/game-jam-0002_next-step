using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public enum Scene
    {
        Level1,
        LoadingScene
    }
    public static Scene targetScene;

    public static void LoaderCallBack()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static void Load(Scene scene)
    {
        targetScene = scene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }
}
