using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] 
    private GameObject prefab;
    [SerializeField]
    private float period;
    [SerializeField]
    private int monsterLimit;
    
    private GameObject _player;
    private GameObject[] _spawners;
    private float _nextActionTime;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spawners = GameObject.FindGameObjectsWithTag("MonsterSpawn");
    }

    private void Update()
    {
        if (!(Time.time > _nextActionTime) || !_spawners.Any())
        {
            return;
        }

        if (GameObject.FindGameObjectsWithTag("Monster").Length >= monsterLimit)
        {
            return;
        }
        
        _nextActionTime += period;
        Vector3 pos = _player.transform.position;
        var spawner = _spawners.Length == 1 ? 
            _spawners.First() :
            _spawners.OrderBy(spawner => (pos - spawner.transform.position).sqrMagnitude).ToArray()[Random.Range(2, _spawners.Length)];
            
        Instantiate(prefab, spawner.transform.position, Quaternion.identity);
    }
}