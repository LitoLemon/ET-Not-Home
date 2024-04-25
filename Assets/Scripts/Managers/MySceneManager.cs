using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static bool loadingScene;
    public static bool won = true;
    public static void LoadNextScene()
    {
        loadingScene = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void LoadLastScene()
    {
        loadingScene = true;
        won = false;
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public static void LoadSpecificScene(int indexNumber)
    {
        loadingScene = true;
        won = true;
        SceneManager.LoadScene(indexNumber);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
