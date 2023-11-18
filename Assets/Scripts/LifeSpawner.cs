using System.Collections;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject heartPrefab;
    private GameObject[] _spawners;
    private GameController _game;

    // Start is called before the first frame update
    void Start()
    {
        _spawners = GameObject.FindGameObjectsWithTag("LifeSpawner");
        _game = FindObjectOfType<GameController>();
        StartCoroutine(ContinuousSpawn());
    }

    public IEnumerator ContinuousSpawn()
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
