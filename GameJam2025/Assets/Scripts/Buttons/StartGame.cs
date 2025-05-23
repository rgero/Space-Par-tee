using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => LevelManager.Instance.LoadLevel("GameScene"));
    }

}
