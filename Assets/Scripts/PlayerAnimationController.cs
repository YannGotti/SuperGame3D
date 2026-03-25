using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MoveController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MoveController moveController;

    private static readonly int SpeedHash = Animator.StringToHash("Speed01");
    private static readonly int MoveXHash = Animator.StringToHash("MoveX");
    private static readonly int MoveYHash = Animator.StringToHash("MoveY");
    private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (moveController == null)
            moveController = GetComponent<MoveController>();
    }

    private void Reset()
    {
        animator = GetComponent<Animator>();
        moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        Vector2 input = moveController.CurrentInput;
        float speed = moveController.NormalizedSpeed;

        animator.SetFloat(SpeedHash, speed);
        animator.SetFloat(MoveXHash, input.x);
        animator.SetFloat(MoveYHash, input.y);
        animator.SetBool(IsMovingHash, speed > 0.01f);
    }
}