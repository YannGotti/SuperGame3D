using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private Transform target;
    [SerializeField] private InputController inputController;

    [Header("Follow")]
    [SerializeField] private Vector3 targetOffset = new Vector3(0f, 1.6f, 0f);
    [SerializeField] private float distance = 4.5f;
    [SerializeField] private float followSmooth = 12f;

    [Header("Look")]
    [SerializeField] private float lookSensitivity = 0.12f;
    [SerializeField] private float minPitch = -25f;
    [SerializeField] private float maxPitch = 60f;

    [Header("Cursor")]
    [SerializeField] private bool lockCursorOnStart = true;

    private float _yaw;
    private float _pitch = 15f;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        _yaw = angles.y;
        _pitch = angles.x;

        if (lockCursorOnStart)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void LateUpdate()
    {
        if (target == null || inputController == null)
            return;

        Vector2 lookInput = inputController.LookDelta;

        _yaw += lookInput.x * lookSensitivity;
        _pitch -= lookInput.y * lookSensitivity;
        _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);

        Quaternion orbitRotation = Quaternion.Euler(_pitch, _yaw, 0f);

        Vector3 pivotPoint = target.position + targetOffset;
        Vector3 desiredPosition = pivotPoint - orbitRotation * Vector3.forward * distance;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSmooth * Time.deltaTime
        );

        transform.LookAt(pivotPoint);
    }
}