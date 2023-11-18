using UnityEngine;

public class AnimationScript : MonoBehaviour {
    public Vector3 rotationAngle;
    public float rotationSpeed;

    public float floatSpeed;
    private bool _goingUp = true;
    public float floatRate;
    private float _floatTimer;
    
	// Update is called once per frame
	void Update () {
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
