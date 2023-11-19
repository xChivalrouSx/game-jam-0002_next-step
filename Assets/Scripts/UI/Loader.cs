using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private static readonly string LEVEL_PREFIX = "Level";

    public enum Scene
    {
        LoadingScene,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
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

    public static void LoadNextLevel()
    {
        int nextSceneIntValue = Int32.Parse(SceneManager.GetActiveScene().name.Replace(LEVEL_PREFIX, string.Empty)) + 1;
        if (Enum.IsDefined(typeof(Scene), LEVEL_PREFIX + nextSceneIntValue.ToString()))
        {
            targetScene = (Scene)(Int32.Parse(SceneManager.GetActiveScene().name.Replace(LEVEL_PREFIX, string.Empty)) + 1);
            SceneManager.LoadScene(Scene.LoadingScene.ToString());
        }
    }


}
