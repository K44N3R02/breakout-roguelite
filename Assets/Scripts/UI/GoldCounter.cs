using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class GoldCounter : MonoBehaviour
{
    private TMP_Text goldText;

    private void Start()
    {
        goldText = GetComponent<TMP_Text>();
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.GoldCountChanged += UpdateText;
            // Initial update
            UpdateText(LevelManager.Instance.GetGold());
        }
    }

    private void OnDestroy()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.GoldCountChanged -= UpdateText;
        }
    }

    private void UpdateText(int goldCount)
    {
        goldText.SetText($"Gold: {goldCount}");
    }
}
