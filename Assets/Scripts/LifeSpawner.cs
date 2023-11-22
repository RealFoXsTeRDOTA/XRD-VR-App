using System.Collections;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject heartPrefab;
    private GameObject[] _spawners;
    private GameController _game;

    private void Start()
    {
        _spawners = GameObject.FindGameObjectsWithTag("LifeSpawner");
        _game = FindObjectOfType<GameController>();
        StartCoroutine(ContinuousSpawn());
    }

    private IEnumerator ContinuousSpawn()
    {
        while (true)
        {
            if (_game.Lives < 3)
            {
                var spawner = _spawners[Random.Range(0, _spawners.Length)];
                Instantiate(heartPrefab, spawner.transform.position, heartPrefab.transform.rotation);
            }

            yield return new WaitForSeconds(30);
        }
    }
}
