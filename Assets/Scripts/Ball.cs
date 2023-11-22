using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    private GameObject _player;
    private const string playerTag = "PlayerTransform";

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(playerTag);
    }

    private void FixedUpdate()
    {
        var playerPosition = _player.transform.position;
        var position = transform.position;

        if ((playerPosition - transform.position).sqrMagnitude > 100)
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
