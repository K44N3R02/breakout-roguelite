using TMPro;
using UnityEngine;

public class LevelCompletedScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    private void Start()
    {
            LevelManager.Instance.OnSuccess += Activate;
            LevelManager.Instance.OnPreparation += Deactivate;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
            LevelManager.Instance.OnSuccess -= Activate;
            LevelManager.Instance.OnPreparation -= Deactivate;
    }

    private void Activate()
    {
            goldText.SetText($"Final Gold: {LevelManager.Instance.GetGold()}");
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
