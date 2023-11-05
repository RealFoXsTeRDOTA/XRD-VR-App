using UnityEngine;

public class FinishHole : MonoBehaviour
{ 
    private GameController game;

    private void Awake()
    {
        game = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        const string golfBallTag = "GolfBall";

        if (!other.CompareTag(golfBallTag))
        {
            return;
        }
        
        game.UpHolesScore();
        Destroy(gameObject);
    }
}
