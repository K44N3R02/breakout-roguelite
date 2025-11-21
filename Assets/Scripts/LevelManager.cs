using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private TMP_Text goldText;

    private InputAction levelStartAction;
    private bool isLevelRunning = false;

    private int goldCount;

    private void Start()
    {
        levelStartAction = InputSystem.actions.FindAction("Level Start");
        levelStartAction.performed += StartBall;
        goldCount = 0;
    }

    private void StartBall(InputAction.CallbackContext context)
    {
        if (!isLevelRunning)
        {
            ball.GetComponent<Rigidbody2D>().linearVelocityY = -10;
            isLevelRunning = true;
        }
    }

    public void AddGold(int amount)
    {
        goldCount += amount;
        goldText.SetText($"Gold: {goldCount}");
    }
}
