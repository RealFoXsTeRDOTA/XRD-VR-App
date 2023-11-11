using UnityEngine;

public class FinishHole : MonoBehaviour
{ 
    private GameController _game;
    
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
        
        _game.UpHolesScore();
        Destroy(gameObject);
    }
}
