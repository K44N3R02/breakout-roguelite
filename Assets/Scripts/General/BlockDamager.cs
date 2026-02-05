using UnityEngine;

public class BlockDamager : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private bool destroyAfterDamage = false;
    [SerializeField] private bool destroyAtWall = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.BLOCK_LAYER)
        {
            collision.gameObject.GetComponent<Health>().ModifyHealth(-damageAmount);
            if (destroyAfterDamage)
            {
                Destroy(gameObject);
            }
        }
        else if (destroyAtWall && collision.gameObject.layer == Constants.WALL_LAYER)
        {
            Destroy(gameObject);
        }
    }

    private void OnValidate()
    {
        if (damageAmount < 0)
        {
            damageAmount = 0;
        }
    }
}
