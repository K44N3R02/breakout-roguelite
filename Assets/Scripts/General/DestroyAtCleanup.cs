using UnityEngine;

public class DestroyAtCleanup : MonoBehaviour
{
    private void Start()
    {
        LevelManager.Instance.OnCleanUp += DestroySelf;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnCleanUp -= DestroySelf;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
