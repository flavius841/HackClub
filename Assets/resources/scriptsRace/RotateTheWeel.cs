using UnityEngine;

public class RotateTheWeel : MonoBehaviour
{
     
    [SerializeField] Rigidbody2D carRigidbody;          // The car’s Rigidbody2D
    [SerializeField] LayerMask groundLayer;    // Assign your ground layer here

    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject MonsterTruck;

    [SerializeField] float wheelRadius;
    [SerializeField] float rotationSmoothness = 10f;
    [SerializeField] float airSpinAcceleration = 300f;  // How fast the wheel spins in air when accelerating
    [SerializeField] float airSpinDecay = 2f;           // How fast the spin slows down when not accelerating
    [SerializeField] float groundCheckDistance = 0.2f;  // Distance to check below wheel
    [SerializeField] ParticleSystem MudParticles;

    [SerializeField] float currentAngularSpeed;
    public Controlingtheplayer Ground1;
    public Controlingtheplayer Ground2;
    public Controlingtheplayer Ground3;
    public RotatePlayer Mud;
    
    void Update()
    {
        //CheckGround();

        float linearSpeed = carRigidbody.linearVelocity.x;
        float targetAngularSpeed;

        if (Ground1.TouchPlayer || Ground2.TouchPlayer || Ground3.TouchPlayer)
        {
            // Use car velocity to set wheel rotation when grounded
            targetAngularSpeed = (linearSpeed / wheelRadius) * Mathf.Rad2Deg;
        }
        else
        {
            // In air — allow spin input
            if (Input.GetAxis("Horizontal") > 0 && currentAngularSpeed < 1200) // accelerate right
            {
                currentAngularSpeed += airSpinAcceleration * Time.deltaTime;
                if (currentAngularSpeed < 0)
                {
                    currentAngularSpeed += airSpinAcceleration * 2 * Time.deltaTime;
                }
            }
            else if (Input.GetAxis("Horizontal") < 0 && currentAngularSpeed > -1200) // accelerate left
            {
                currentAngularSpeed -= airSpinAcceleration * Time.deltaTime;
                if (currentAngularSpeed > 0)
                {
                    currentAngularSpeed -= airSpinAcceleration * 2 * Time.deltaTime;
                }
            }
            else
            {
                // Slow down spin gradually when no input
                currentAngularSpeed = Mathf.Lerp(currentAngularSpeed, 0, Time.deltaTime * airSpinDecay);
            }

            if (FormulaCar.activeInHierarchy)
            {
                if (Mud.TouchMud && currentAngularSpeed > 700)
                {
                    MudParticles.transform.localPosition = new Vector3(15.6f, -3.8f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.Play();
                }

                else if (Mud.TouchMud && currentAngularSpeed < -700)
                {
                    MudParticles.transform.localPosition = new Vector3(21.9f, -3.9f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.Play();
                }

                else
                {
                    MudParticles.Stop();
                }
            }
            
            if (MonsterTruck.activeInHierarchy)
            {
                if (Mud.TouchMud && currentAngularSpeed > 200)
                {
                    MudParticles.transform.localPosition = new Vector3(-7.9f, 4.22f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.Play();
                }

                else if (Mud.TouchMud && currentAngularSpeed < -200)
                {
                    MudParticles.transform.localPosition = new Vector3(10.8f, 4.22f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.Play();
                }

                else
                {
                    MudParticles.Stop();
                }
            }


            targetAngularSpeed = currentAngularSpeed;
        }

        // Smoothly transition when grounded (prevents snapping)
        currentAngularSpeed = Mathf.Lerp(currentAngularSpeed, targetAngularSpeed, Time.deltaTime * rotationSmoothness);

        // Rotate visually
        transform.Rotate(Vector3.forward, -currentAngularSpeed * Time.deltaTime);
    }

    // void CheckGround()
    // {
    //     // Raycast downward from the wheel's center
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    //     Ground1.TouchPlayer = hit.collider != null;
    // }
}
