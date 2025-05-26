using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        StatSystem.Instance.ResetScore();
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => LevelManager.Instance.LoadLevel("Level_01"));
    }

}
