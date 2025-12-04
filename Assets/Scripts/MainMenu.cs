using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scenes")]
    public string gameSceneName = "Game";      // nombre de la escena del juego
    public string settingsSceneName = "Settings"; // nombre de la escena de settings

    // START GAME
    public void PlayGame()
    {
        Debug.Log("START PRESSED");
        SceneManager.LoadScene(gameSceneName);
    }

    // OPEN SETTINGS SCENE
    public void OpenSettings()
    {
        Debug.Log("SETTINGS PRESSED");
        SceneManager.LoadScene(settingsSceneName);
    }

    // QUIT GAME
    public void QuitGame()
    {
        Debug.Log("QUIT PRESSED — game would close in build");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
