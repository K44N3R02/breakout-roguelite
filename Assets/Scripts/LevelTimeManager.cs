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
    public int TimeLeft { get; private set; }

    public void SetLevelTimer(int levelTime)
    {
        if (countdownRoutine != null)
        {
            return;
        }
        TimeLeft = levelTime;
    }

    public void StopLevelTimer()
    {
        if (countdownRoutine == null)
        {
            return;
        }
        StopCoroutine(countdownRoutine);
        countdownRoutine = null;
    }

    public void ContinueLevelTimer()
    {
        if (countdownRoutine != null)
        {
            return;
        }
        countdownRoutine = StartCoroutine(LevelCountdownRoutine());
    }

    private IEnumerator LevelCountdownRoutine()
    {
        TimerStart?.Invoke(TimeLeft);
        while (TimeLeft > 0)
        {
            yield return _waitForSeconds1;
            TimeLeft--;
            TimerTick?.Invoke(TimeLeft);
        }
        TimerEnded?.Invoke();
    }
}
