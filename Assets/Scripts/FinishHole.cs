using UnityEngine;

public class FinishHole : MonoBehaviour
{ 
    private GameController _game;

    private void Awake()
    {
        _game = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        const string golfBallTag = "GolfBall";

        if (!other.CompareTag(golfBallTag))
        {
            return;
        }
        
        _game.UpHolesScore();
        Destroy(gameObject);
    }
}
