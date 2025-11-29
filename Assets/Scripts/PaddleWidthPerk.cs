using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PaddleWidthPerk : MonoBehaviour
{
    [System.Serializable]
    struct ModifierAndChance
    {
        public float modifier;
        public int relativeChance;
    }

    [SerializeField] private Sprite expandSprite;
    [SerializeField] private Sprite shrinkSprite;
    [SerializeField] private ModifierAndChance modifier1;
    [SerializeField] private ModifierAndChance modifier2;

    private SpriteRenderer spriteRenderer;
    private float widthModifier;

    private void Start()
    {
        float random = Random.Range(0f, 1f);
        float mod1chance = ((float)modifier1.relativeChance) / (modifier1.relativeChance + modifier2.relativeChance);
        widthModifier = (random < mod1chance) ? modifier1.modifier : modifier2.modifier;
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
