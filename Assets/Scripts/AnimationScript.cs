using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private float rotationSpeed;
    [SerializeField] public float floatSpeed;
    [SerializeField] public float floatRate;

    private bool _goingUp = true;
    private float _floatTimer;
    
    private void Update ()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
        
        _floatTimer += Time.deltaTime;
        Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
        transform.Translate(moveDir);

        if (_goingUp && _floatTimer >= floatRate)
        {
            _goingUp = false;
            _floatTimer = 0;
            floatSpeed = -floatSpeed;
        }
        else if(!_goingUp && _floatTimer >= floatRate)
        {
            _goingUp = true;
            _floatTimer = 0;
            floatSpeed = +floatSpeed;
        }
    }
}
