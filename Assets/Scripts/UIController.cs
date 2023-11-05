using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _holesScore; 
    
    [SerializeField] 
    private TextMeshProUGUI _hitsScore;
    
    [SerializeField] 
    private TextMeshProUGUI _killsScore;
    
    public void SetHolesScore(int score)
    {
        _holesScore.text = $"Holes: {score}";
    }
    
    public void SetHitsScore(int score)
    {
        _hitsScore.text = $"Hits: {score}";
    }
    
    public void SetKillsScore(int score)
    {
        _killsScore.text = $"Kills: {score}";
    }
}