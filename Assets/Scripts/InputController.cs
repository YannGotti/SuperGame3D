using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Vector2 _deltaVector;
    public Vector2 DeltaMove 
    {
        get { return _deltaVector; }
        set { _deltaVector = value; }
    }
    
    // Обработчик движения
    public void HandlerMove(InputAction.CallbackContext ctx)
    {
        _deltaVector = ctx.ReadValue<Vector2>();
    }
}