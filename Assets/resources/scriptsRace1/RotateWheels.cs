using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    [SerializeField] Rigidbody2D carRigidbody;
    public Controlingtheplayer script1;
    private float currentAngularSpeed;
    public float wheelRadius;
    void Start()
    {
        
    }

    void Update()
    {
        float speed = carRigidbody.linearVelocity.magnitude;

        if (script1.TouchPlayer)
        {
            currentAngularSpeed = (speed / (2 * Mathf.PI * wheelRadius)) * 360f;
        }

        else
        {
            currentAngularSpeed = Mathf.Lerp(currentAngularSpeed, 0, Time.deltaTime * 0.2f);
        }

        transform.Rotate(Vector3.forward, -currentAngularSpeed * Time.deltaTime);    }
}
