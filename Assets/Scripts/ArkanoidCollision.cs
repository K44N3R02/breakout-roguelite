using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArkanoidCollision : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PADDLE_LAYER)
        {
            rigidbody.linearVelocity = (transform.position - collision.transform.position).normalized
                                       * Mathf.Sqrt(rigidbody.linearVelocity.sqrMagnitude);
        }
    }
}
