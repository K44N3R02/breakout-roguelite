using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum LevelState { Preparation, Ready, Running, Success, Fail }

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public LevelState State { get; private set; }

    // Events for transitions
    public event Action OnPreparation;
    public event Action OnReady;
    public event Action OnRunning;
    public event Action OnSuccess;
    public event Action OnFail;
    public event Action OnCleanUp;

    public event Action<int> GoldCountChanged;

    // Internal State
    public LevelTimeManager levelTime;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ball;
    [SerializeField] private BallConfig ballConfig;
    private int ballCount = 0;

    [SerializeField] private PlayerHealth playerHealth;
    private int tileCount = 0;
    private int level = 1;
    private int goldCount = 0;
    private InputAction levelStartAction;

    [Header("Level Generation")]
    [SerializeField] private GameObject levelGeneratorObject;
    [SerializeField] private List<GameObject> tiles;
    private ILevelGenerator levelGenerator;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        levelStartAction = InputSystem.actions.FindAction("Level Start");
        levelStartAction.performed += _ =>
        {
            OnStartInput();
        };

        levelTime.TimerEnded += () =>
        {
            SetState(LevelState.Fail);
        };

        DeadZone.OnBallDestroyed += HandleBallDestroyed;
        DeadZone.OnGrabbableDestroyed += HandleGrabbableDestroyed;

        levelGenerator = levelGeneratorObject.GetComponent<ILevelGenerator>();

        goldCount = 0;
        GoldCountChanged?.Invoke(goldCount);

        SetState(LevelState.Preparation);
    }

    private void SetState(LevelState newState)
    {
        // Exit logic
        if (State == LevelState.Running)
        {
            levelTime.StopLevelTimer();
        }

        State = newState;

        // Enter logic
        switch (State)
        {
            case LevelState.Preparation:
                OnCleanUp?.Invoke();
                OnPreparation?.Invoke();
                tileCount = levelGenerator.GenerateLevel(tiles, level, OnTileDeath);
                levelTime.SetLevelTimer(90);
                SetState(LevelState.Ready);
                break;

            case LevelState.Ready:
                OnCleanUp?.Invoke();
                RespawnBall();
                OnReady?.Invoke();
                break;

            case LevelState.Running:
                levelTime.ContinueLevelTimer();
                LaunchBall();
                OnRunning?.Invoke();
                break;

            case LevelState.Success:
                OnCleanUp?.Invoke();
                OnSuccess?.Invoke();
                level++;
                break;

            case LevelState.Fail:
                OnFail?.Invoke();
                break;
        }
    }

    private void OnStartInput()
    {
        if (State == LevelState.Ready)
        {
            SetState(LevelState.Running);
        }
    }

    public void NextLevel()
    {
        if (State == LevelState.Success)
        {
            SetState(LevelState.Preparation);
        }
    }

    private void OnTileDeath()
    {
        tileCount--;
        if (tileCount <= 0 && State == LevelState.Running)
        {
            SetState(LevelState.Success);
        }
    }

    private void HandleBallDestroyed()
    {
        ballCount--;

        if (ballCount <= 0)
        {
            playerHealth.ModifyHealth(-1);

            if (playerHealth.CurrentHealth > 0)
            {
                SetState(LevelState.Ready);
            }
            else
            {
                SetState(LevelState.Fail);
            }
        }
    }

    private void RespawnBall()
    {
        if (ball != null)
        {
            Destroy(ball);
        }
        ballCount = 1;
        ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

    private void LaunchBall()
    {
        if (ball != null)
        {
            ball.GetComponent<Rigidbody2D>().linearVelocityY = -ballConfig.Speed;
        }
    }

    public void AddGold(int amount)
    {
        goldCount += amount;
        GoldCountChanged?.Invoke(goldCount);
    }

    public int GetGold()
    {
        return goldCount;
    }

    private void HandleGrabbableDestroyed() { }

    private void OnDestroy()
    {
        DeadZone.OnBallDestroyed -= HandleBallDestroyed;
        DeadZone.OnGrabbableDestroyed -= HandleGrabbableDestroyed;
    }
}
