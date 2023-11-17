using UnityEngine;

public class MonsterKiller : MonoBehaviour
{
    private const string _monsterTag = "Monster";
    private GameController _game;
    private Rigidbody _rigidBody;
    [SerializeField] private bool destroyGameObjectOnImpact;
    [SerializeField] private bool checkForMinVelocity;
    private const float minVelocityForKill = 7.5f;

    private void Start()
    {
        _game = FindObjectOfType<GameController>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(_monsterTag))
        {
            return;
        }

        if (checkForMinVelocity && _rigidBody.velocity.magnitude < minVelocityForKill)
        {
            return;
        }

        other.GetComponent<MonsterController>().PlayDeathSound();
        Destroy(other.gameObject);
        _game.UpKillsScore();

        if (destroyGameObjectOnImpact)
        {
            Destroy(gameObject);
        }
    }
}
