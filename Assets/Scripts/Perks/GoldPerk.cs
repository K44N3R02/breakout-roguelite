using UnityEngine;

public class GoldPerk : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PADDLE_LAYER)
        {
            LevelManager.Instance.AddGold(1);
            Destroy(gameObject);
        }
    }
}
