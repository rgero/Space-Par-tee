using UnityEngine;

public class Gravity : MonoBehaviour
{

  public float targetGravity = 9.81f;
  public float targetDrag = 1f;

  public GameObject gravityField;

  void Awake()
  {
    double spriteRadius = this.gameObject.GetComponent<CircleCollider2D>().radius;

    if (gravityField)
      gravityField.transform.localScale = new Vector3((float)spriteRadius * 2, (float)spriteRadius * 2, 1);
  }

  void OnTriggerStay2D(Collider2D collision)
  {
    Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
    if (rb)
    {
      Vector2 direction = (transform.position - rb.transform.position).normalized;
      float distance = Vector2.Distance(transform.position, rb.transform.position);
      float force = targetGravity / (distance * distance);
      rb.AddForce(direction * force, ForceMode2D.Force);
      rb.linearDamping = targetDrag;
    }
  }

  void OnTriggerExit2D(Collider2D collision)
  {
    Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
    if (rb)
    {
      rb.linearDamping = 0f;
    }
  }
}
