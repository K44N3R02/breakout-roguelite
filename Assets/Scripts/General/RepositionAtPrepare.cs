using UnityEngine;

public class RepositionAtPrepare : MonoBehaviour
{
    [SerializeField] private Transform initialPosition;

    private void Start()
    {
        LevelManager.Instance.OnReady += ResetPosition;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnReady -= ResetPosition;
    }

    private void ResetPosition()
    {
        transform.SetPositionAndRotation(initialPosition.position, initialPosition.rotation);
    }
}
