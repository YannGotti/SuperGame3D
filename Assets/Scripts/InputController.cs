using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Vector2 _deltaVector;
    private Vector2 _lookVector;

    public Vector2 DeltaMove => _deltaVector;
    public Vector2 LookDelta => _lookVector;

    public void HandlerMove(InputAction.CallbackContext ctx)
    {
        _deltaVector = ctx.ReadValue<Vector2>();
    }

    public void HandlerLook(InputAction.CallbackContext ctx)
    {
        _lookVector = ctx.ReadValue<Vector2>();
    }
}