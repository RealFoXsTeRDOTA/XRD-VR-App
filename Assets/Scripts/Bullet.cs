using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }
}
