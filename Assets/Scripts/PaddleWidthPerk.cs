using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PaddleWidthPerk : MonoBehaviour
{
    [SerializeField] private Sprite expandSprite;
    [SerializeField] private Sprite shrinkSprite;
    [SerializeField] private float widthModifier = 0.5f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = (widthModifier >= 0) ? expandSprite : shrinkSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PADDLE_LAYER)
        {
            collision.gameObject.GetComponent<PaddleScaler>().ScaleByPercent(widthModifier);
            Destroy(gameObject);
        }
    }
}
