using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField] private float lifeInSeconds;

    private float timer;

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeInSeconds)
        {
            Destroy(gameObject);
        }
    }
}
