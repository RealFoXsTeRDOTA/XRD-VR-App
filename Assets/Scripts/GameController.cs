using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _holesScore;
    private int _hitsScore;
    private int _killsScore;
    private int _lives;
    private UIController _uiController;

    [SerializeField] private GameObject _holePrefab;
    [SerializeField] private GameObject[] _holeSpawnPositions;
    private Vector3 _lastSpawnPosition;

    public void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
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
            randomSpawnPosition = _holeSpawnPositions[Random.Range(0, _holeSpawnPositions.Length)].transform.position;
        } while (randomSpawnPosition == _lastSpawnPosition);

        _lastSpawnPosition = randomSpawnPosition;
        Instantiate(_holePrefab, randomSpawnPosition, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
    }

    private void UpHolesScore()
    {
        _holesScore++;
        _uiController.SetHolesScore(_holesScore);
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
        //_uiController.SetLives(_lives);
    }
}
