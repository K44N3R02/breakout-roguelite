using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallSpeedPerk : MonoBehaviour
{
    [System.Serializable]
    struct ModifierAndChance
    {
        public float modifier;
        public int relativeChance;
    }

    [SerializeField] private Sprite speedUpSprite;
    [SerializeField] private Sprite speedDownSprite;
    [SerializeField] private ModifierAndChance modifier1;
    [SerializeField] private ModifierAndChance modifier2;
    [SerializeField] private BallConfig ballConfig;

    private SpriteRenderer spriteRenderer;
    private float speedChange;

    private void Start()
    {
        float random = Random.Range(0f, 1f);
        float mod1chance = ((float)modifier1.relativeChance) / (modifier1.relativeChance + modifier2.relativeChance);
        speedChange = (random < mod1chance) ? modifier1.modifier : modifier2.modifier;
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
