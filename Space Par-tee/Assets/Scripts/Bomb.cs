using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
    }
}
