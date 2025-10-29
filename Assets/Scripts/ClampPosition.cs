using UnityEngine;

public class ClampPosition : MonoBehaviour
{
    [SerializeField] private Vector2 topLeft;
    [SerializeField] private Vector2 bottomRight;

    private void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, topLeft.x, bottomRight.x);
        newPosition.y = Mathf.Clamp(newPosition.y, topLeft.y, bottomRight.y);
        transform.position = newPosition;
    }
}
