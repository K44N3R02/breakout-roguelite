using UnityEngine;
using TMPro;
public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI finalGoldText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        finalGoldText.SetText($"Final Gold: {score}");
    }
}
