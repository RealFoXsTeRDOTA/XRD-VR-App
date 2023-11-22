using TMPro;
using UnityEngine;

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
    private GameObject[] images;
    private GameController _gameController;
 
    private void Start()
    {
        deathCanva.SetActive(false);
        rayInteractor.SetActive(false);
        _gameController = FindObjectOfType<GameController>();
        _gameController.LifeChangedEvent.AddListener(SetLives);
        _gameController.KillsChangedEvent.AddListener(SetKillsScore);
        _gameController.HitsChangedEvent.AddListener(SetHitsScore);
        _gameController.HolesChangedEvent.AddListener(SetHolesScore);
    }

    private void SetHolesScore(int score)
    {
        holesScore.text = $"Holes: {score}";
    }

    private void SetHitsScore(int score)
    {
        hitsScore.text = $"Hits: {score}";
    }

    private void SetKillsScore(int score)
    {
        killsScore.text = $"Kills: {score}";
    }

    private void SetLives(int lives)
    {
        for (var i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i < lives);
        }

        if (lives <= 0)
        {
            deathCanva.SetActive(true);
            rayInteractor.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        _gameController.LifeChangedEvent.RemoveListener(SetLives);
        _gameController.KillsChangedEvent.RemoveListener(SetKillsScore);
        _gameController.HitsChangedEvent.RemoveListener(SetHitsScore);
        _gameController.HolesChangedEvent.RemoveListener(SetHolesScore);
    }
}