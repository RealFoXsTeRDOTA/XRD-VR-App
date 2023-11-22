using System.Collections;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private GameController _game;
    [SerializeField] private AudioClip healEffect;
    [SerializeField] private AudioClip heartAudio;
    [SerializeField] private int lifetimeInSeconds;

    private const string playerTag = "Player";

    private void Start()
    {
        _game = FindObjectOfType<GameController>();
        AudioSource.PlayClipAtPoint(heartAudio, transform.position);
        Destroy(gameObject, lifetimeInSeconds);
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
}
