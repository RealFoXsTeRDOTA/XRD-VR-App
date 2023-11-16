using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;

    private void Start()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(_ => StartShooting());
    }

    private void StartShooting()
    {
        Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
    }
}
