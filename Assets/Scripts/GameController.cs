using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private GameObject[] holeSpawnPositions;

    public UnityEvent<int> HitsChangedEvent { get; } = new UnityEvent<int>();
    public UnityEvent<int> LifeChangedEvent { get; } = new UnityEvent<int>();
    public UnityEvent<int> KillsChangedEvent { get; } = new UnityEvent<int>();
    public UnityEvent<int> HolesChangedEvent { get; } = new UnityEvent<int>();

    private int _holesScore;
    private int _hitsScore;
    private int _killsScore;
    private int _lives = 3;
    private Club _club;
    private SpawnController _spawnController;
    private GameObject _golfBall;
    private Vector3 _lastSpawnPosition;

    [SerializeField] private Transform target;
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Transform xrCamera;

    private void Start()
    {
        _spawnController = GetComponent<SpawnController>();
        _golfBall = GameObject.FindGameObjectWithTag("GolfBall");
        _club = FindObjectOfType<Club>();
        _club.BallHitEvent.AddListener(UpHitsScore);
        LifeChangedEvent?.Invoke(_lives);
        SpawnRandomHole();
    }

    public void HitBallInHole()
    {
        UpHolesScore();
        SpawnRandomHole();
    }

    private void SpawnRandomHole()
    {
        Vector3 randomSpawnPosition;

        do
        {
            randomSpawnPosition = holeSpawnPositions[Random.Range(0, holeSpawnPositions.Length)].transform.position;
        } while (randomSpawnPosition == _lastSpawnPosition);

        _lastSpawnPosition = randomSpawnPosition;
        Instantiate(holePrefab, randomSpawnPosition, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
    }

    private void UpHolesScore()
    {
        _holesScore++;
        HolesChangedEvent?.Invoke(_holesScore);

        switch (_holesScore)
        {
            case 1:
            case 3:
                StartCoroutine(_spawnController.SpawnMonsters(1));
                break;
            case 2:
                Instantiate(gunPrefab, _golfBall.transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);
                StartCoroutine(_spawnController.SpawnMonsters(2, 5));
                break;
            case 4:
                StartCoroutine(_spawnController.StartContinuousSpawn());
                break;
        }
    }
    
    private void UpHitsScore()
    {
        _hitsScore++;
        HitsChangedEvent?.Invoke(_hitsScore);
    }
    
    public void UpKillsScore()
    {
        _killsScore++;
        KillsChangedEvent?.Invoke(_killsScore);
    }

    public void DownLife()
    {
        _lives--;
        LifeChangedEvent?.Invoke(_lives);

        if (_lives == 0)
        {
            _spawnController.enabled = false;
            var monsters = GameObject.FindGameObjectsWithTag("Monster");

            foreach (var monster in monsters)
            {
                Destroy(monster);
            }

            var weapons = GameObject.FindGameObjectsWithTag("Club").ToList();
            weapons.AddRange(GameObject.FindGameObjectsWithTag("Weapon"));

            foreach (var weapon in weapons)
            {
                Destroy(weapon);
            }

            var lifeSpawner = GetComponent<LifeSpawner>();
            lifeSpawner.enabled = false;
        }
    }
    
    public void UpLife()
    {
        if (_lives < 3)
        {
            _lives++;
            LifeChangedEvent?.Invoke(_lives);
        }
    }

    public void Restart()
    {
        var offset = xrCamera.position - xrOrigin.position;
        offset.y = 0;
        xrOrigin.position = target.position - offset;

        var targetForward = target.forward;
        targetForward.y = 0;
        var cameraForward = xrCamera.forward;
        cameraForward.y = 0;

        var angle = Vector3.SignedAngle(cameraForward, targetForward, Vector3.up);
        xrOrigin.RotateAround(xrCamera.position, Vector3.up, angle);

        SceneManager.LoadScene(0);
    }

    public int Lives => _lives;

    private void OnDestroy()
    {
        _club.BallHitEvent.RemoveListener(UpHitsScore);
    }
}
