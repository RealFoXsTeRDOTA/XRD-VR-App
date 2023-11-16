using UnityEngine;

public class MonsterKiller : MonoBehaviour
{
    private const string _monsterTag = "Monster";
    private GameController _game;
    [SerializeField] private bool destroyGameObjectOnImpact;

    private void Start()
    {
        _game = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(_monsterTag))
        {
            return;
        }

        Destroy(other.gameObject);
        _game.UpKillsScore();

        if (destroyGameObjectOnImpact)
        {
            Destroy(gameObject);
        }
    }
}
