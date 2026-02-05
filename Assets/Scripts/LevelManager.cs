using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    // Internal State
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ball;
    [SerializeField] private BallConfig ballConfig;
    private int ballCount = 1;

    [SerializeField] private PlayerHealth playerHealth;
    private int tileCount = 0;
    private int level = 1;
    private InputAction levelStartAction;
    private bool isLevelRunning = false;
    private int goldCount;
    private bool isGameOver = false;

    // Level Generation
    [SerializeField] private GameObject levelGeneratorObject;
    [SerializeField] private List<GameObject> tiles;
    private ILevelGenerator levelGenerator;

    // UI
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private GameObject levelCompletedScreen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        levelStartAction = InputSystem.actions.FindAction("Level Start");
        levelStartAction.performed += StartBall;
        goldCount = 0;
        DeadZone.OnBallDestroyed += HandleBallDestroyed;
        DeadZone.OnGrabbableDestroyed += HandleGrabbableDestroyed;

        levelGenerator = levelGeneratorObject.GetComponent<ILevelGenerator>();
        tileCount = levelGenerator.GenerateLevel(tiles, level, OnTileDeath);

        if (ball == null)
        {
            RespawnBall();
        }
        else
        {
            ballCount = 1;
        }
    }

    private void OnTileDeath()
    {
        tileCount--;
        if (tileCount <= 0)
        {
            ClearLevel();
        }
    }

    private void ClearLevel()
    {
        isLevelRunning = false;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        level++;
        levelCompletedScreen.SetActive(true);
    }

    public void NextLevel()
    {
        Destroy(ball);
        levelCompletedScreen.SetActive(false);
        tileCount = levelGenerator.GenerateLevel(tiles, level, OnTileDeath);
        RespawnBall();
    }

    private void StartBall(InputAction.CallbackContext context)
    {
        if (!isLevelRunning)
        {
            ball.GetComponent<Rigidbody2D>().linearVelocityY = -ballConfig.Speed;
            isLevelRunning = true;
        }
    }

    public void AddGold(int amount)
    {
        goldCount += amount;
        goldText.SetText($"Gold: {goldCount}");
    }

    void OnDestroy()
    {
        DeadZone.OnBallDestroyed -= HandleBallDestroyed;
        DeadZone.OnGrabbableDestroyed -= HandleGrabbableDestroyed;
    }

    void HandleBallDestroyed()
    {
        ballCount--;


        if (ballCount <= 0)
        {
            if (playerHealth != null)
            {
                playerHealth.ModifyHealth(-1);
            }

            if (playerHealth.CurrentHealth > 0)
            {

                Debug.Log("ball destroyed, Respawning Ball");

                RespawnBall();
            }
            else
            {

                Debug.Log("Gameover");

                triggerGameOver();
            }
        }


    }
    void RespawnBall()
    {
        ballCount = 1;
        isLevelRunning = false;
        ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
    }



    void HandleGrabbableDestroyed()
    {
    }

    public void triggerGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over triggered.");
            gameOverScreen.Setup(goldCount);
        }


    }
}
