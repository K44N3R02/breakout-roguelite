using UnityEngine;
using System.Collections;
using System;

public class LevelTimeManager : MonoBehaviour
{
    /// <summary>
    /// Gives time left to end of level as parameter
    /// </summary>
    public event Action<int> TimerStart;
    /// <summary>
    /// Gives time left to end of level as parameter
    /// </summary>
    public event Action<int> TimerTick;
    public event Action TimerEnded;

    private static readonly WaitForSeconds _waitForSeconds1 = new(1);
    private Coroutine countdownRoutine;
    private int levelTimeLeft;

    public void StartLevelTimer(int levelTime)
    {
        if (countdownRoutine != null)
            return;
        levelTimeLeft = levelTime;
        countdownRoutine = StartCoroutine(LevelCountdownRoutine());
    }

    public int StopLevelTimer()
    {
        if (countdownRoutine == null)
            return -1;
        StopCoroutine(countdownRoutine);
        countdownRoutine = null;
        return levelTimeLeft;
    }

    public void ContinueLevelTimer()
    {
        if (countdownRoutine != null)
            return;
        countdownRoutine = StartCoroutine(LevelCountdownRoutine());
    }

    private IEnumerator LevelCountdownRoutine()
    {
        TimerStart?.Invoke(levelTimeLeft);
        while (levelTimeLeft > 0)
        {
            yield return _waitForSeconds1;
            levelTimeLeft--;
            TimerTick?.Invoke(levelTimeLeft);
        }
        TimerEnded?.Invoke();
    }
}
