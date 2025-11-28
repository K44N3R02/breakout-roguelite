using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallSpeed : MonoBehaviour
{
    [SerializeField] private BallConfig ballConfig;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ballConfig.OnBallSpeedChange += UpdateSpeed;
    }


    private void OnDisable()
    {
        ballConfig.OnBallSpeedChange -= UpdateSpeed;
    }

    private void UpdateSpeed()
    {
        rb2d.linearVelocity = rb2d.linearVelocity.normalized * ballConfig.Speed;
    }
}
