using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 12f;
    [SerializeField] private Transform cameraTransform;

    public Vector2 CurrentInput { get; private set; }
    public float NormalizedSpeed { get; private set; }

    private void Awake()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    public void Move(Vector2 deltaVector)
    {
        CurrentInput = deltaVector;

        float inputMagnitude = Mathf.Clamp01(deltaVector.magnitude);
        NormalizedSpeed = inputMagnitude;

        if (inputMagnitude <= 0.01f)
            return;

        Vector3 forward;
        Vector3 right;

        if (cameraTransform != null)
        {
            forward = cameraTransform.forward;
            right = cameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();
        }
        else
        {
            forward = Vector3.forward;
            right = Vector3.right;
        }

        Vector3 moveDirection = forward * deltaVector.y + right * deltaVector.x;

        if (moveDirection.sqrMagnitude <= 0.0001f)
            return;

        moveDirection.Normalize();

        transform.position += moveDirection * speed * inputMagnitude * Time.deltaTime;

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}