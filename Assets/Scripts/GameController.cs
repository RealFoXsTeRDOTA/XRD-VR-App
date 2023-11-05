using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _holesScore;
    private int _hitsScore;
    private int _killsScore;
    private int _lives;
    private UIController _uiController;

    public void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
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
        //_uiController.SetLives(_lives);
    }
}
