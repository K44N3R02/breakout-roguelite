using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PADDLE_LAYER)
        {
            GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>().AddGold(1);
            Destroy(gameObject);
        }
    }
}
