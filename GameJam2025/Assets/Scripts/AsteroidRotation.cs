using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    public float rotationSpeed = 0.0f;
    public float rotationSpeedMin = 0.0f;
    public float rotationSpeedMax = 30.0f;
    public bool rotationDirection = true;

    void Start()
    {
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        rotationDirection = Random.Range(0, 2) == 0;
    }

    void Update()
    {
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime * (rotationDirection ? 1 : -1));
    }
}
