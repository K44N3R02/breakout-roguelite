using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class LevelTimer : MonoBehaviour
{
    private TMP_Text timerText;

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
        if (LevelManager.Instance != null && LevelManager.Instance.levelTime != null)
        {
            LevelManager.Instance.levelTime.TimerStart += UpdateTimerText;
            LevelManager.Instance.levelTime.TimerTick += UpdateTimerText;
            LevelManager.Instance.levelTime.TimerEnded += () => { UpdateTimerText(0); };
        }
    }

    private void UpdateTimerText(int levelTime)
    {
        float minutes = Mathf.FloorToInt(levelTime / 60);
        float seconds = Mathf.FloorToInt(levelTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
