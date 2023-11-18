using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private GameObject[] holeSpawnPositions;
    
    private int _holesScore;
    private int _hitsScore;
    private int _killsScore;
    private int _lives = 3;
    private UIController _uiController;
    private SpawnController _spawnController;
    private GameObject _camera;
    private Vector3 _lastSpawnPosition;

    public void Start()
    {
        _uiController = FindObjectOfType<UIController>();
        _spawnController = FindObjectOfType<SpawnController>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        _uiController.SetLives(_lives);
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
        _uiController.SetHolesScore(_holesScore);

        switch (_holesScore)
        {
            case 1:
            case 3:
                StartCoroutine(_spawnController.SpawnMonsters(1));
                break;
            case 2:
                Instantiate(gunPrefab, _camera.transform.position + new Vector3(0f, 2f, 2f), Quaternion.identity);
                StartCoroutine(_spawnController.SpawnMonsters(2, 5));
                break;
            default:
                StartCoroutine(_spawnController.StartContinuousSpawn());
                break;
        }
    }
    
    public void UpHitsScore()
    {
        _hitsScore++;
        _uiController.SetHitsScore(_hitsScore);
    }
    
    public void UpKillsScore()
    {
        _killsScore++;
        _uiController.SetKillsScore(_killsScore);
    }

    public void DownLife()
    {
        _lives--;
        _uiController.SetLives(_lives);
    }
}
