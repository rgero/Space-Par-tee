using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    void StartNewGame()
    {
        StatSystem.Instance.ResetScore();
        LevelManager.Instance.LoadLevel("Level_01");
    }

    void Awake()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(StartNewGame);
    }

}
