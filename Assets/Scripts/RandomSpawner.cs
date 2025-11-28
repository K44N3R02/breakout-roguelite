using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
struct PerkAndSpawnChance
{
    public GameObject perk;
    public int relativeSpawnChance;
}

[RequireComponent(typeof(Health))]
public class RandomSpawner : MonoBehaviour
{
    /// <summary>
    /// Chance to spawn any perk on the Perk List
    /// </summary>
    [SerializeField] private float spawnChance;

    /// <summary>
    /// List of perks and their spawn rates relative to each other
    /// </summary>
    [SerializeField] private List<PerkAndSpawnChance> perkList;

    private float[] chances;
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
        health.OnDeath += SpawnOnDeath;
        PrecalculateSpawnChances();
    }

    private void SpawnOnDeath()
    {
        float random = Random.Range(0f, 1f);

        if (random < spawnChance)
        {
            GameObject spawnee = perkList[ChoosePerkToSpawn()].perk;
            Instantiate(spawnee, transform.position, transform.rotation);
        }
    }

    private void PrecalculateSpawnChances()
    {
        chances = new float[perkList.Count];
        float sum = 0;
        for (int i = 0; i < perkList.Count; i++)
        {
            sum += perkList[i].relativeSpawnChance;
            chances[i] = sum;
        }
        for (int i = 0; i < chances.Length; i++)
        {
            chances[i] /= sum;
        }
    }

    private int ChoosePerkToSpawn()
    {
        float random = Random.Range(0f, 1f);
        for (int i = 0; i < chances.Length; i++)
        {
            if (random < chances[i])
            {
                return i;
            }
        }
        Debug.LogError("No perks could be selected");
        return 0;
    }

    private void OnValidate()
    {
        spawnChance = Mathf.Clamp01(spawnChance);
    }
}
