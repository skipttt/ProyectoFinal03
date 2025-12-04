using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [Header("Scenes")]
    public string mainMenuSceneName = "MainMenu"; // nombre de la escena de menú

    public void BackToMainMenu()
    {
        Debug.Log("BACK TO MAIN MENU PRESSED");
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT PRESSED FROM SETTINGS — game would close in build");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
