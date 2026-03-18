using UnityEngine;

// https://www.mixamo.com/#/ (vpn)
public class CollisionController : MonoBehaviour
{
    [SerializeField] Vector3 _spawnPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red"))
            transform.position = _spawnPos;
            
    }
}
