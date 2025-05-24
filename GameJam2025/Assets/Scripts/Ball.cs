using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance { get; private set; }
    public float targetForce = 5f;
    public bool hasFired = false;

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
    }

    public void Fire()
    {
        if (!hasFired)
        {
            hasFired = true;
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * targetForce, ForceMode2D.Impulse);
        }
    }
}
