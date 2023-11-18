using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{    
    [SerializeField] 
    private GameObject deathCanva;

    [SerializeField] 
    private TextMeshProUGUI holesScore;

    [SerializeField] 
    private TextMeshProUGUI hitsScore;

    [SerializeField] 
    private TextMeshProUGUI killsScore;
    
    [SerializeField] 
    private GameObject rayInteractor;

    [SerializeField]
    private GameObject spawnController;

    [SerializeField]
    private GameObject[] images;
    private GameObject _player;
    private Vector3 _playerInitialPosition;
 
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        deathCanva.SetActive(false);
        rayInteractor.SetActive(false);
    }

    public void SetHolesScore(int score)
    {
        holesScore.text = $"Holes: {score}";
    }

    public void SetHitsScore(int score)
    {
        hitsScore.text = $"Hits: {score}";
    }

    public void SetKillsScore(int score)
    {
        killsScore.text = $"Kills: {score}";
    }

    public void SetLives(int lives)
    {
        for (var i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i < lives);
        }

        if (lives <= 0)
        {
            deathCanva.SetActive(true);
            rayInteractor.SetActive(true);
            spawnController.SetActive(false);
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
        }
    } 
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _player.transform.position = _playerInitialPosition;
    }
}