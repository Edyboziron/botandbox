using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Hazard trigger (spikes, acid, fall zones) that resets the active scene when the player or the box touches it.
/// </summary>
public class SceneResetTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
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
