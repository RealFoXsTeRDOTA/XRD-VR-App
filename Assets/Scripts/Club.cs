using UnityEngine;

public class Club : MonoBehaviour
{    
    private const string GolfBallTag = "GolfBall";
    private GameController _game;
    private float? _lastShotTime;
    private const float HitCooldown = 1f;
    private AudioSource _audioSource;

    private void Start()
    {
        _game = FindObjectOfType<GameController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(GolfBallTag))
        {
            return;
        }

        if (_lastShotTime != null && Time.time < _lastShotTime + HitCooldown)
        {
            return;
        }

        _lastShotTime = Time.time;
        _game.UpHitsScore();
        _audioSource.Play();
    }
}