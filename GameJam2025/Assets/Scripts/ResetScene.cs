using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void OnResetButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
