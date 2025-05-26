using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleCompleted : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Optional: check if the next scene index is within range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available. You are at the last scene.");
        }
    }
}
