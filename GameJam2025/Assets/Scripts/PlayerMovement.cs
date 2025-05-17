using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float targetForce = 5f;
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * targetForce, ForceMode2D.Impulse);
    }
}
