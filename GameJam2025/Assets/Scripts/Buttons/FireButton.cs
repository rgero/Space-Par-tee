using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    void Awake()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => Ball.Instance.Fire());
    }
}
