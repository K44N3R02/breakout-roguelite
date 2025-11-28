using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallSpeedPerk : MonoBehaviour
{
    [SerializeField] private Sprite speedUpSprite;
    [SerializeField] private Sprite speedDownSprite;
    [SerializeField] private float speedChange = 10f;
    [SerializeField] private BallConfig ballConfig;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = (speedChange >= 0) ? speedUpSprite : speedDownSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PADDLE_LAYER)
        {
            ballConfig.Speed += speedChange;
            Destroy(gameObject);
        }
    }
}
