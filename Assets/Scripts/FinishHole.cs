using UnityEngine;

public class FinishHole : MonoBehaviour
{ 
    private GameController _game;
    [SerializeField] private AudioClip audioClip;
    
    private const string golfBallTag = "GolfBall";

    private void Start()
    {
        _game = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(golfBallTag))
        {
            return;
        }
        
        if (other.attachedRigidbody.velocity.magnitude > 3f)
        {
            return;
        }

        _game.HitBallInHole();
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        Destroy(gameObject);
    }
}
