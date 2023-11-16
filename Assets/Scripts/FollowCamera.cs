using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject _camera;

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        var cameraPosition = _camera.transform.position;
        transform.position = new Vector3(cameraPosition.x, transform.position.y, cameraPosition.z);
    }
}
