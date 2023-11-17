using UnityEngine;

public class Club : MonoBehaviour
{    
    private const string golfBallTag = "GolfBall";
    private GameController _game;
    private Vector3 currentPosition;
    private Vector3 lastPosition;
    [SerializeField] private float maxVelocity;
    private float? _lastShotTime;
    private float _hitCooldown = 1f;

    private void Start()
    {
        _game = FindObjectOfType<GameController>();
        //currentPosition = transform.position;
        //lastPosition = transform.position;
    }

    // TODO - Fix
    //private void FixedUpdate()
    //{
    //    lastPosition = currentPosition;
    //    currentPosition = transform.position;
    //}

    //private Vector3 GetCurrentVelocity()
    //{
    //    var velocity = ((currentPosition - lastPosition) / Time.deltaTime);
    //    var velocityMagnitude = velocity.magnitude;

    //    if (velocityMagnitude > maxVelocity)
    //    {
    //        velocity *= (maxVelocity / velocityMagnitude);
    //    }

    //    return velocity;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.gameObject.CompareTag(golfBallTag))
    //    {
    //        return;
    //    }

    //    Debug.Log("Ball hit!");
    //    _game.UpHitsScore();
    //    var velocity = GetCurrentVelocity();
    //    other.attachedRigidbody.velocity = velocity;
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(golfBallTag))
        {
            return;
        }

        if (_lastShotTime != null && Time.time < _lastShotTime + _hitCooldown)
        {
            return;
        }

        _lastShotTime = Time.time;
        _game.UpHitsScore();
    }
}