using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => LevelManager.Instance.LoadLevel("GameScene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
