using UnityEngine;
using TMPro;

public class SceneTimeManager : MonoBehaviour
{
    
    [SerializeField] private float levelTime = 60f; 
    private bool isTimerRunning = true;

    public TMP_Text timerText;      

    void Update()
    {
        
        if (!isTimerRunning) return;

        if (levelTime > 0)
        {
            
            levelTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            levelTime = 0;
            isTimerRunning = false;
            UpdateTimerText();

            
            LevelManager.Instance.triggerGameOver(); 
            Time.timeScale = 0f;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {

            float minutes = Mathf.FloorToInt(levelTime / 60);
            float seconds = Mathf.FloorToInt(levelTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
