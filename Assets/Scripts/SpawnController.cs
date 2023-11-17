using System.Collections;
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
    [SerializeField] private float timeBetweenIndividualSpawns;
    
    private GameObject _player;
    private GameObject[] _spawners;
    private AudioSource _audioSource;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _spawners = GameObject.FindGameObjectsWithTag("MonsterSpawn");
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            while (GameObject.FindGameObjectsWithTag("Monster").Length < monsterLimit)
            {
                Vector3 pos = _player.transform.position;
                var spawner = _spawners.Length == 1 ?
                    _spawners.First() :
                    _spawners.OrderBy(spawner => (pos - spawner.transform.position).sqrMagnitude)
                             .ToArray()[Random.Range(2, _spawners.Length)];

                Instantiate(prefab, spawner.transform.position, Quaternion.identity);
                _audioSource.Play();
                yield return new WaitForSeconds(timeBetweenIndividualSpawns);
            }

            yield return new WaitForSeconds(period);
        }
    }
}