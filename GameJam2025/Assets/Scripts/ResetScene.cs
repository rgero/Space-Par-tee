using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void OnResetButtonClick()
    {
        LevelManager.Instance.ResetLevel();
    }
}
