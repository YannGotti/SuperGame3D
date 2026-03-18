using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed;

    public void Move(Vector2 deltaVector)
    {
        if (deltaVector == Vector2.zero)
            return;

        transform.position += speed * Time.deltaTime * new Vector3(deltaVector.x, 0, deltaVector.y);
    }
}