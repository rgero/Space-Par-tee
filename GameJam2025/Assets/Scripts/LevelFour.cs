using UnityEngine;

public class LevelFour : MonoBehaviour
{
    public GameObject[] obstacles;
    public int obstacleCount = 10;
    public float spawnRadius = 15f;

    public float rotationSpeed = 10f;

    public Transform centerObject;    

    void Start()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            float angle = i * Mathf.PI * 2f / obstacleCount;
            Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;
            Vector2 spawnPosition = (Vector2)centerObject.position + offset;

            GameObject obstacle = Instantiate(
                obstacles[Random.Range(0, obstacles.Length)],
                spawnPosition,
                Quaternion.identity
            );

            obstacle.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
