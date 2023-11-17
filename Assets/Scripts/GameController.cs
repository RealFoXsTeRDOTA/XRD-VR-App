using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private GameObject[] holeSpawnPositions;
    
    private int _holesScore;
    private int _hitsScore;
    private int _killsScore;
    private int _lives = 3;
    private UIController _uiController;
    private Vector3 _lastSpawnPosition;
    
    private const string clubTag = "Club";

    public void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
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

    public void UpHolesScore()
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
        _uiController.SetLives(_lives);
    }
}
