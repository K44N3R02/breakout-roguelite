using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{   
    public GameOverScreen GameOverScreen;
    [SerializeField] private GameObject ball;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private BallConfig ballConfig;
    [SerializeField] private Canvas startScreen;

    public PlayerHealth playerHealth; 

    [SerializeField] private GameObject ballPrefab; 
    [SerializeField] private Transform spawnPoint;
    private int ballCount = 1;
    private InputAction levelStartAction;
    private bool isLevelRunning = false;

    private int goldCount;
    private bool isGameOver = false;
    private void Start()
    {
        levelStartAction = InputSystem.actions.FindAction("Level Start");
        levelStartAction.performed += StartBall;
        goldCount = 0;
        DeadZone.OnBallDestroyed += HandleBallDestroyed;
        DeadZone.OnGrabbableDestroyed += HandleGrabbableDestroyed;
        
        if (ball == null)
        {
            RespawnBall(); 
        }
        else
        {
            ballCount = 1; 
        }
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
   
    
    if (ballCount <= 0 )
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

void triggerGameOver()
{
    if (!isGameOver)
    {
        isGameOver = true;
        Debug.Log("Game Over triggered.");
        GameOverScreen.Setup(goldCount);
    }


}
}
