using UnityEngine;
using UnityEngine.Events;

public class Club : MonoBehaviour
{    
    private const string GolfBallTag = "GolfBall";
    private GameController _game;
    private float? _lastShotTime;
    private const float HitCooldown = 1f;
    private AudioSource _audioSource;

    public UnityEvent BallHitEvent { get; } = new UnityEvent();

    private void Start()
    {
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
        BallHitEvent?.Invoke();
        _audioSource.Play();
    }
}