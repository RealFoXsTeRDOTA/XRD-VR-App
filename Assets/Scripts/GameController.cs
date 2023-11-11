using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameController : MonoBehaviour
{
    private int _holesScore;
    private int _hitsScore;
    private int _killsScore;
    private int _lives = 3;
    private UIController _uiController;
    
    private const string clubTag = "Club";

    public void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
        _uiController.SetLives(_lives);
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

        if (_lives <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag(clubTag));
        }
    }
}
