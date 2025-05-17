using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float targetForce = 5f;

    public bool hasFired = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !hasFired)
        {
            hasFired = true;
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * targetForce, ForceMode2D.Impulse);
        }
    }
}
