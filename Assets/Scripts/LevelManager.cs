using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{   
    public GameOverScreen GameOverScreen;
    [SerializeField] private GameObject ball;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private BallConfig ballConfig;

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
        Debug.Log(" Ball Destroyed");
        triggerGameOver();
    }

    
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
