using UnityEngine;

public class PeriodicSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnee;
    [SerializeField] private float period;

    private float timer;

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= period)
        {
            Instantiate(spawnee, transform.position, transform.rotation);
            timer = 0f;
        }
    }
}
