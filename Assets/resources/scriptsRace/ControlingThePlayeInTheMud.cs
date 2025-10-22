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



    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();

        if (MonsterTruck.activeInHierarchy)
        {
            MaxSpeed = MaxSpeed + 20;
            carRigidbody = MonsterTruck.GetComponent<Rigidbody2D>();
            LowestSpeed = LowestSpeed - 10;

        }

        if (FormulaCar.activeInHierarchy)
        {
            carRigidbody = FormulaCar.GetComponent<Rigidbody2D>();
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
