using UnityEngine;

[RequireComponent(typeof(Health))]
public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private float spawnChance;
    [SerializeField] private GameObject spawnee;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
        health.OnDeath += SpawnOnDeath;
    }

    private void SpawnOnDeath()
    {
        float random = Random.Range(0f, 1f);

        if (random < spawnChance)
        {
            Instantiate(spawnee, transform.position, transform.rotation);
        }
    }

    private void OnValidate()
    {
        spawnChance = Mathf.Clamp01(spawnChance);
    }
}
