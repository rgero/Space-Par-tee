using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance { get; private set; }
    public float targetForce = 5f;
    public bool hasFired = false;
    public GameObject movementContainer;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one Ball! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        hasFired = false;
        movementContainer.SetActive(true);
    }

    public void Fire()
    {
        if (!hasFired)
        {
            hasFired = true;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            float zRotation = transform.eulerAngles.z;
            float radians = zRotation * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

            this.GetComponent<Rigidbody2D>().AddForce(direction * targetForce, ForceMode2D.Impulse);
            movementContainer.SetActive(false);
        }
    }
}
