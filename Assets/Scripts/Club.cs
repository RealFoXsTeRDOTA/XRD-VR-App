using UnityEngine;

public class Club : MonoBehaviour
{
    private GameController _game;
    
    private const string golfBallTag = "GolfBall";
    private const string monsterTag = "Monster";

    private void Awake()
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
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(monsterTag))
        {
            return;
        }
        
        Destroy(other.gameObject);
        _game.UpKillsScore();
    }
}