using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shootCooldown;
    private AudioSource _audioSource;
    private float? _lastShotTime;

    private void Start()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(_ => StartShooting());
        _audioSource = GetComponent<AudioSource>();
    }

    private void StartShooting()
    {
        if (_lastShotTime != null && Time.time < _lastShotTime + shootCooldown) {
            return;
        }

        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawnPosition.position;
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPosition.forward * bulletSpeed;
        Destroy(bullet, 3);
        _lastShotTime = Time.time;
        _audioSource.Play();
    }
}
