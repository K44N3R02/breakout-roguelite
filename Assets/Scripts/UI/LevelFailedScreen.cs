using TMPro;
using UnityEngine;

public class LevelFailedScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;

    private void Start()
    {
        LevelManager.Instance.OnFail += Activate;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnFail -= Activate;
    }

    private void Activate()
    {
        goldText.SetText($"Final Gold: {LevelManager.Instance.GetGold()}");
        gameObject.SetActive(true);
    }
}
