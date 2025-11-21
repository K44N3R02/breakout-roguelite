using UnityEngine;

public class BlockDamager : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.BLOCK_LAYER)
        {
            collision.gameObject.GetComponent<Health>().ModifyHealth(-damageAmount);
            Debug.Log("Hit!");
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
