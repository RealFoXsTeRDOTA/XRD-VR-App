using System.Collections;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private GameController _game;
    [SerializeField] private AudioClip healEffect;
    [SerializeField] private AudioClip heartAudio;

    private const string playerTag = "Player";

    void Start()
    {
        _game = FindObjectOfType<GameController>();
        AudioSource.PlayClipAtPoint(heartAudio, transform.position);
        StartCoroutine(DestroyItselfCoroutine());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            AudioSource.PlayClipAtPoint(healEffect, transform.position);
            _game.UpLife();
            Destroy(gameObject);
        }
       
    }
    
    private IEnumerator DestroyItselfCoroutine()
    { 
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
