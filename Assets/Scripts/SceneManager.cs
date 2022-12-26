using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManager
{
    // Function to load a new scene
    public static void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    // Function to reload the current scene
    public static void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
