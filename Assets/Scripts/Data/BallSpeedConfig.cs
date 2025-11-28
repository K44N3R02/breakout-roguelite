using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallConfig", menuName = "Game/Ball Config")]
public class BallConfig : ScriptableObject
{
    [SerializeField] private float initialSpeed = 10f;
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
            if (speed != value)
            {
                speed = value;
                OnBallSpeedChange();
            }
        }
    }
}
