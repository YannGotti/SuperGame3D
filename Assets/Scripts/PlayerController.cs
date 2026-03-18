using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(MoveController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private MoveController _moveController;

    private void Awake()
    {
        _inputController = GetComponent<InputController>();
        _moveController = GetComponent<MoveController>();
    }

    private void Reset()
    {
        _inputController = GetComponent<InputController>();
        _moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        _moveController.Move(_inputController.DeltaMove);
    }
}