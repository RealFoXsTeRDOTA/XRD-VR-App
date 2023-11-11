using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] 
    private GameObject healthBar;
    
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
    
    private RawImage[] _images;
    private GameObject _player;
    private Vector3 _playerInitialPosition;
 
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _images = healthBar.GetComponentsInChildren<RawImage>();
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
        for (var i = 0; i < _images.Length; i++)
        {
            _images[i].enabled = i < lives;
        }

        if (lives <= 0)
        {
            deathCanva.SetActive(true);
            rayInteractor.SetActive(true);
        }
    } 
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _player.transform.position = _playerInitialPosition;
    }
}