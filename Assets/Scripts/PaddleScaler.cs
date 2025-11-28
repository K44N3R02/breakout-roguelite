using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(CapsuleCollider2D))]
public class PaddleScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CapsuleCollider2D collider2d;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<CapsuleCollider2D>();
    }

    /// <summary>
    /// Scale the width of the paddle multiplicatively.
    /// </summary>
    /// <param name="percent">Amount of scale where 0f is no scaling</param>
    public void ScaleByPercent(float percent)
    {
        float scaler = 1f + percent;
        Vector2 newSize = spriteRenderer.size;
        newSize.x *= scaler;
        spriteRenderer.size = newSize;
        newSize = collider2d.size;
        newSize.x = spriteRenderer.size.x - 0.1f;
        collider2d.size = newSize;
    }

    [ContextMenu("Double")]
    public void Double()
    {
        ScaleByPercent(1f);
    }

    [ContextMenu("Halve")]
    public void Halve()
    {
        ScaleByPercent(-0.5f);
    }
}
