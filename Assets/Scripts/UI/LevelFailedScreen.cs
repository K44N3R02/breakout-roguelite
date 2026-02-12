using TMPro;
using UnityEngine;

public class LevelFailedScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    private void Start()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.EndLevelFail += Activate;
        }
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.EndLevelFail -= Activate;
        }
    }

    private void Activate()
    {
        if (goldText != null)
        {
            goldText.SetText($"Final Gold: {LevelManager.Instance.GetGold()}");
        }
        gameObject.SetActive(true);
    }
}
