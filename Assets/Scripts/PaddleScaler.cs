using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(CapsuleCollider2D))]
public class PaddleScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CapsuleCollider2D collider2d;
    [SerializeField] private float maxScaling = 1.5f;
    [SerializeField] private float minScaling = 2/3f;

    private float currentScaling = 1f;

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
        scaler = ClampScaling(scaler);
        Vector2 newSize = spriteRenderer.size;
        newSize.x *= scaler;
        spriteRenderer.size = newSize;
        newSize = collider2d.size;
        newSize.x = spriteRenderer.size.x - 0.1f;
        collider2d.size = newSize;
    }

    private float ClampScaling(float scaler)
    {
        float newScaling = currentScaling * scaler;
        if (newScaling > maxScaling)
        {
            float finalScaling = maxScaling / currentScaling;
            currentScaling = maxScaling;
            return finalScaling;
        }
        else if (newScaling < minScaling)
        {
            float finalScaling = minScaling / currentScaling;
            currentScaling = minScaling;
            return finalScaling;
        }
        else
        {
            currentScaling = newScaling;
            return scaler;
        }
    }
}
