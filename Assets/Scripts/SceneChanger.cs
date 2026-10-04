using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Trigger volume that transitions the game to a specified scene when the player enters.
/// </summary>
public class SceneChanger : MonoBehaviour
{
    [Tooltip("Target build index of the scene to load.")]
    [SerializeField] private int sceneIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
