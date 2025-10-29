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

    private void HandleMouseAction(InputAction.CallbackContext context)
    {
        Vector3 new_position = transform.position;
        new_position.x = Camera.main.ScreenToWorldPoint(new Vector2(context.ReadValue<float>(), 0)).x;
        transform.position = new_position;
    }

    private void HandleTouchAction(InputAction.CallbackContext context)
    {
        float screenDeltaX = context.ReadValue<float>();

        // Get the ratio of world units per pixel
        // For an orthographic camera, this is a standard idiom.
        float pixelsPerUnit = Camera.main.pixelHeight / (2.0f * Camera.main.orthographicSize);

        float worldDeltaX = screenDeltaX / pixelsPerUnit;
        transform.position += new Vector3(worldDeltaX, 0, 0);
    }
}
