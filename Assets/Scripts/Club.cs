using UnityEngine;

public class Club : MonoBehaviour
{    
    private const string golfBallTag = "GolfBall";
    private GameController _game;

    private void Start()
    {
        _game = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(golfBallTag))
        {
            return;
        }

        _game.UpHitsScore();
    }
}