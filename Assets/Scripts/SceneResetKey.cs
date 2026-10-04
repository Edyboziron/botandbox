using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the restart key ('R') to quickly reload the active scene.
/// </summary>
public class SceneResetKey : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
