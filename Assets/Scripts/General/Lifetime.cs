using System.Collections;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField] private float lifeInSeconds;

    private void Start()
    {
        StartCoroutine(DestroyRoutine());
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(lifeInSeconds);
        Destroy(gameObject);
    }
}
