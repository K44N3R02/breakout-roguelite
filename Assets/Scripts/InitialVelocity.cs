using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InitialVelocity : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity = new(0f, 0f);

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.linearVelocity = initialVelocity;
    }
}
