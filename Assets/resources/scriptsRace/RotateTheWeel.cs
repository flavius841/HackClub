using UnityEngine;

public class RotateTheWeel : MonoBehaviour
{
     
    [SerializeField] Rigidbody2D carRigidbody;          // The car’s Rigidbody2D
    [SerializeField] LayerMask groundLayer;    
    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject MonsterTruck;
    [SerializeField] GameObject NormalCar;
    [SerializeField] GameObject RallyCar;

    [SerializeField] float wheelRadius;
    [SerializeField] float rotationSmoothness = 10f;
    [SerializeField] float airSpinAcceleration = 300f;  // How fast the wheel spins in air when accelerating
    [SerializeField] float airSpinDecay = 2f;           // How fast the spin slows down when not accelerating
    [SerializeField] float groundCheckDistance = 0.2f;  // Distance to check below wheel
    //[SerializeField] ParticleSystem MudParticles;
    [SerializeField] float TimerForMud;
    [SerializeField] GameObject MudParticles;


    [SerializeField] float currentAngularSpeed;
    public Controlingtheplayer Ground1;
    public Controlingtheplayer Ground2;
    public Controlingtheplayer Ground3;
    public ControlingThePlayeInTheMud Mud;
    
    void Update()
    {
        //CheckGround();

        Debug.Log(currentAngularSpeed);

        float linearSpeed = carRigidbody.linearVelocity.x;
        float targetAngularSpeed;

        if (Mud.TouchPlayer)
        {
            TimerForMud = 0;

        }

        else
        {
            TimerForMud += Time.deltaTime;
        }

        if (Ground1.TouchPlayer || Ground2.TouchPlayer || Ground3.TouchPlayer)
        {
            // Use car velocity to set wheel rotation when grounded
            targetAngularSpeed = (linearSpeed / wheelRadius) * Mathf.Rad2Deg;
        }
        else
        {

            // if (MudParticles.isPlaying)
            // {
            //     Debug.Log("MudParticles are currently playing!");
            // }
            // else
            // {
            //     Debug.Log("MudParticles are NOT playing!");
            // }


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
                if (Mud.TouchPlayer && currentAngularSpeed > 700)
                {
                    MudParticles.transform.localPosition = new Vector3(15.6f, -3.8f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.gameObject.SetActive(true);
                }

                else if (Mud.TouchPlayer && currentAngularSpeed < -700)
                {
                    MudParticles.transform.localPosition = new Vector3(21.9f, -3.9f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.gameObject.SetActive(true);
                }

                else
                {
                    MudParticles.gameObject.SetActive(false);
                }
            }

            else if (MonsterTruck.activeInHierarchy)
            {
                if (Mud.TouchPlayer && currentAngularSpeed > 200)
                {
                    MudParticles.transform.localPosition = new Vector3(-7.9f, 4.22f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.gameObject.SetActive(true);
                }

                else if (Mud.TouchPlayer && currentAngularSpeed < -200)
                {
                    MudParticles.transform.localPosition = new Vector3(10.8f, 4.22f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.gameObject.SetActive(true);
                }

                else
                {
                    MudParticles.gameObject.SetActive(false);
                }
            }

            else if (NormalCar.activeInHierarchy)
            {
                if (Mud.TouchPlayer && currentAngularSpeed > 500)
                {
                    MudParticles.transform.localPosition = new Vector3(-67.64f, 46.5032f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -239.164f);
                    MudParticles.gameObject.SetActive(true);
                }

                else if (Mud.TouchPlayer && currentAngularSpeed < -500)
                {
                    MudParticles.transform.localPosition = new Vector3(-65.2f, 46.5032f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.gameObject.SetActive(true);
                }

                else
                {
                    MudParticles.gameObject.SetActive(false);
                }
            }

            else
            {
                if (Mud.TouchPlayer && currentAngularSpeed > 700)
                {
                    MudParticles.transform.localPosition = new Vector3(-70.41497f, 121.6882f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.gameObject.SetActive(true);
                }

                else if (Mud.TouchPlayer && currentAngularSpeed < -700)
                {
                    MudParticles.transform.localPosition = new Vector3(-59f, 121.6882f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.gameObject.SetActive(true);
                }

                else if (TimerForMud > 0.2f || (currentAngularSpeed > -700 && currentAngularSpeed < 700)) 
                {
                    MudParticles.gameObject.SetActive(false);
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
