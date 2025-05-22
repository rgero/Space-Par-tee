using UnityEngine;

public class HoleCompleted : MonoBehaviour
{
    public string nextLevelName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        LevelManager.Instance.LoadLevel(nextLevelName);
    }
}
