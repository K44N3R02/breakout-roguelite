using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallConfig", menuName = "Game/Ball Config")]
public class BallConfig : ScriptableObject
{
    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float minSpeed = 5f;
    [NonSerialized] private float speed;

    public event Action OnBallSpeedChange;

    private void OnEnable()
    {
        speed = initialSpeed;
    }

    public float Speed
    {
        get { return speed; }
        set
        {
            float clampedSpeed = Mathf.Clamp(value, minSpeed, maxSpeed);
            if (speed != clampedSpeed)
            {
                speed = clampedSpeed;
                OnBallSpeedChange();
            }
        }
    }
}
