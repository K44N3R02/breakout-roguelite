using System.Collections;
using UnityEngine;

public class PeriodicSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnee;
    [SerializeField] private float period;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(period);
            Instantiate(spawnee, transform.position, transform.rotation);
        }
    }
}
