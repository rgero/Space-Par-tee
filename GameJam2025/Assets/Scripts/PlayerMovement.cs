using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float targetForce = 5f;

    public bool hasFired = false;

    public void Fire()
    {
        if (!hasFired)
        {
            hasFired = true;
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * targetForce, ForceMode2D.Impulse);
        }
    }
}
