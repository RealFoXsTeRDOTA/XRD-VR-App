using UnityEngine;

public class FinishHole : MonoBehaviour
{ 
    private GameController _game;
    [SerializeField] private AudioClip audioClip;
    
    private const string golfBallTag = "GolfBall";

    private void Awake()
    {
        _game = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(golfBallTag))
        {
            return;
        }
        
        Debug.Log(other.attachedRigidbody.velocity.magnitude);
        if (other.attachedRigidbody.velocity.magnitude > 3f)
        {
            return;
        }

        _game.HitBallInHole();
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        Destroy(gameObject);
    }
}
