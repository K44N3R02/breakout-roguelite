using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControl : MonoBehaviour
{
    private InputAction mouseAction;
    private InputAction touchAction;

    void Start()
    {
        mouseAction = InputSystem.actions.FindAction("Move Debug");
        touchAction = InputSystem.actions.FindAction("Move Touch");

        mouseAction.performed += HandleMouseAction;
        touchAction.performed += HandleTouchAction;

        Debug.Log("Paddle Control Start");
    }

    private void OnDisable()
    {
        mouseAction.performed -= HandleMouseAction;
        touchAction.performed -= HandleTouchAction;
    }

    private void HandleMouseAction(InputAction.CallbackContext context)
    {
        float screenPositionX = context.ReadValue<float>();

        float pixelsPerUnit = Camera.main.pixelHeight / (2.0f * Camera.main.orthographicSize);

        float worldPositionX = screenPositionX / pixelsPerUnit;
        transform.position = new Vector3(worldPositionX, transform.position.y, transform.position.z);
    }

    private void HandleTouchAction(InputAction.CallbackContext context)
    {
        float screenDeltaX = context.ReadValue<float>();

        float pixelsPerUnit = Camera.main.pixelHeight / (2.0f * Camera.main.orthographicSize);

        float worldDeltaX = screenDeltaX / pixelsPerUnit;
        transform.position += new Vector3(worldDeltaX, 0, 0);
    }
}
