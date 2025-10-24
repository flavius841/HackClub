using UnityEngine;

public class ControlingThePlayeInTheMud : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    public bool TouchPlayer;
    public float MaxSpeed, Acc, LowestSpeed, inerty;
    [SerializeField] Rigidbody2D carRigidbody;
    [SerializeField] float normalInerty;
    [SerializeField] float HighInerty;
    [SerializeField] float PositiveInerty;
    [SerializeField] int angleimparted;
    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject MonsterTruck;
    [SerializeField] GameObject NormalCar;
    [SerializeField] GameObject RallyCar;
    [SerializeField] ParticleSystem MudParticles;
    [SerializeField] float currentAngularSpeed;
    [SerializeField] float airSpinAcceleration = 300f;
    [SerializeField] float airSpinDecay = 2f;  





    void Start()
    {
        
        surfaceEffector = GetComponent<SurfaceEffector2D>();

        if (MonsterTruck.activeInHierarchy)
        {
            MaxSpeed = MaxSpeed + 20;
            carRigidbody = MonsterTruck.GetComponent<Rigidbody2D>();
            LowestSpeed = LowestSpeed - 10;

        }

        else if (FormulaCar.activeInHierarchy)
        {
            carRigidbody = FormulaCar.GetComponent<Rigidbody2D>();
        }

        else if (NormalCar.activeInHierarchy)
        {
            carRigidbody = NormalCar.GetComponent<Rigidbody2D>();
        }

        else
        {
            carRigidbody = RallyCar.GetComponent<Rigidbody2D>();
            MaxSpeed = MaxSpeed + 10;
            LowestSpeed = LowestSpeed - 5;
        }

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            TouchPlayer = true;
        }
    }
    
   

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            TouchPlayer = false;
        }
    }

    void Update()
    {
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
                if (TouchPlayer && currentAngularSpeed > 100)
                {
                    MudParticles.transform.localPosition = new Vector3(15.6f, -3.8f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.Play();
                }

                else if (TouchPlayer && currentAngularSpeed < -100)
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

            else if (MonsterTruck.activeInHierarchy)
            {
                if (TouchPlayer && currentAngularSpeed > 100)
                {
                    MudParticles.transform.localPosition = new Vector3(-7.9f, 4.22f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.Play();
                }

                else if (TouchPlayer && currentAngularSpeed < -100)
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

            else if (NormalCar.activeInHierarchy)
            {
                if (TouchPlayer && currentAngularSpeed > 100)
                {
                    MudParticles.transform.localPosition = new Vector3(-67.64f, 46.5032f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -239.164f);
                    MudParticles.Play();
                }

                else if (TouchPlayer && currentAngularSpeed < -100)
                {
                    MudParticles.transform.localPosition = new Vector3(-65.2f, 46.5032f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.Play();
                }

                else
                {
                    MudParticles.Stop();
                }
            }

            else
            {
                if (TouchPlayer && currentAngularSpeed > 100)
                {
                    MudParticles.transform.localPosition = new Vector3(-70.41497f, 121.6882f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -240.255f);
                    MudParticles.Play();
                }

                else if (TouchPlayer && currentAngularSpeed < -100)
                {
                    MudParticles.transform.localPosition = new Vector3(-59f, 121.6882f, 0f);
                    MudParticles.transform.rotation = Quaternion.Euler(0, 0, -366.285f);
                    MudParticles.Play();
                }

                else
                {
                    MudParticles.Stop();
                }
            }

        float linearSpeed = carRigidbody.linearVelocity.x;

        float angle = carRigidbody.rotation;

        if (angle > 26f)
        {
            inerty = HighInerty;
        }

        else
        {
            inerty =   normalInerty;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SurfaceEffector2D>().enabled = true;
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, LowestSpeed, Acc * Time.deltaTime);
        }


        else if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<SurfaceEffector2D>().enabled = true;
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, MaxSpeed, Acc * Time.deltaTime);

        }

        else if (angle >= 7 && linearSpeed > 0)
        {
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, 0, HighInerty * Time.deltaTime);
        }

        else if (angle < -7 && linearSpeed < 0)
        {
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, 0, HighInerty * Time.deltaTime);
        }

        else if (angle < -7 && linearSpeed < -angle)
        {
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, -angle/angleimparted, PositiveInerty * Time.deltaTime);

        }
        else if (angle >= 7 && linearSpeed < angle)
        {
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, -angle/angleimparted, PositiveInerty * Time.deltaTime);
        }

        else if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            // GetComponent<SurfaceEffector2D>().enabled = false;
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, 0, inerty * Time.deltaTime);

        }
    }
}
