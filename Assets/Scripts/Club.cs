using UnityEngine;

public class Club : MonoBehaviour
{
    private GameController _game;

    private void Awake()
    {
        _game = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        const string golfBallTag = "GolfBall";
        if (!other.gameObject.CompareTag(golfBallTag))
        {
            return;
        }

        _game.UpHitsScore();
    }
}