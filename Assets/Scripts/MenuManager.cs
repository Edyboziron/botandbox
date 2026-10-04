using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles UI buttons for menu transitions and quitting the game.
/// </summary>
public class MenuManager : MonoBehaviour
{
    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
