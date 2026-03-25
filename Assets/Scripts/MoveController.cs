using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    public Vector2 CurrentInput { get; private set; }
    public float NormalizedSpeed { get; private set; }

    public void Move(Vector2 deltaVector)
    {
        CurrentInput = deltaVector;

        Vector3 move = new Vector3(deltaVector.x, 0f, deltaVector.y);
        float inputMagnitude = Mathf.Clamp01(deltaVector.magnitude);
        NormalizedSpeed = inputMagnitude;

        if (inputMagnitude <= 0.01f)
            return;

        transform.position += move.normalized * speed * inputMagnitude * Time.deltaTime;

        // Поворот в сторону движения
        transform.forward = move.normalized;
    }
}