using UnityEngine;

public class LaserPerk : MonoBehaviour
{
    [SerializeField] private GameObject laserSpawner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.layer == Constants.PADDLE_LAYER)
        {
            for (int i = 0; i < collidedObject.transform.childCount; i++)
            {
                GameObject child = collidedObject.transform.GetChild(i).gameObject;
                if (child.TryGetComponent(out PeriodicSpawner _))
                {
                    Destroy(child);
                }
            }
            Instantiate(laserSpawner, collidedObject.transform);
            Destroy(gameObject);
        }
    }
}
