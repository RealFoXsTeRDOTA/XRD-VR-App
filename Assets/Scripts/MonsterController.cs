using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private GameObject _player;
    private GameController _game;
    [SerializeField] private AudioClip deathSoundEffect;
    [SerializeField] private AudioClip reachPlayerSoundEffect;

    private const string playerTag = "PlayerTransform";

    private void Start()
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
            AudioSource.PlayClipAtPoint(reachPlayerSoundEffect, transform.position);
            Destroy(gameObject);
        }
    }

    public void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathSoundEffect, transform.position);
    }
}
