using UnityEngine;

public class Bat : MonoBehaviour
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
        _game.UpHitsScore();
    }
}