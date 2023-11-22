using System.Collections;
using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int period;
    [SerializeField] private int monsterLimit;
    [SerializeField] private float timeBetweenIndividualSpawns;
    [SerializeField] private GameController gameController;
    
    private GameObject _player;
    private GameObject[] _spawners;
    private AudioSource _audioSource;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spawners = GameObject.FindGameObjectsWithTag("MonsterSpawn");
        _audioSource = GetComponent<AudioSource>();
        gameController.HolesChangedEvent.AddListener(ModifyDifficulty);
    }

    public IEnumerator SpawnMonsters(int count, int? initialWaitingTime = null)
    {
        if (initialWaitingTime != null && initialWaitingTime > 0)
        {
            yield return new WaitForSeconds((int)initialWaitingTime);
        }
        
        for (var i = 0; i < count; i++)
        {
            SpawnMonster();
            yield return new WaitForSeconds(timeBetweenIndividualSpawns);
        }
    }

    public IEnumerator StartContinuousSpawn()
    {
        while (true)
        {
            for (var i = 0; i < monsterLimit; i++)
            {
                SpawnMonster();
                yield return new WaitForSeconds(timeBetweenIndividualSpawns);
            }
            
            yield return new WaitForSeconds(period);
        }
    }

    private void SpawnMonster()
    {
        var pos = _player.transform.position;
        var spawner = _spawners.Length == 1 ?
            _spawners.First() :
            _spawners.OrderBy(s => (pos - s.transform.position).sqrMagnitude)
                .ToArray()[Random.Range(1, _spawners.Length)];

        Instantiate(prefab, spawner.transform.position, Quaternion.identity);
        _audioSource.Play();
    }

    private void ModifyDifficulty(int score)
    {
        Debug.Log(score);
        if (score < 5)
        {
            return;
        }
        else if (score >= 5 && score < 8)
        {
            monsterLimit = 4;
            period = 30;
        }
        else if (score >= 8 && score < 10)
        {
            monsterLimit = 5;
            timeBetweenIndividualSpawns = 3;
        }
        else
        {
            monsterLimit = 6;
            period = 15;
            timeBetweenIndividualSpawns = 1.5f;
        }
    }

    private void OnDestroy()
    {
        gameController.HolesChangedEvent.RemoveListener(ModifyDifficulty);
    }
}