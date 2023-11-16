using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameObject _player;
    private GameController _game;
    
    private const string playerTag = "Player";

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(playerTag);
        _game = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
        transform.LookAt(_player.transform);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            _game.DownLife();
            Destroy(gameObject);
        }
    }
}
