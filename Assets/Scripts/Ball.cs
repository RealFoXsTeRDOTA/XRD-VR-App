using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    private LineRenderer lineRenderer;
    private GameObject _player;
    private Rigidbody _rigidbody;

    private const string playerTag = "Player";

    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(playerTag);
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition = _player.transform.position;
        var position = transform.position;
        if ((playerPosition - transform.position).sqrMagnitude > 100 && _rigidbody.velocity.magnitude < 0.005)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, position);
            lineRenderer.SetPosition(1, new Vector3(position.x, position.y + 20, position.z));
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
