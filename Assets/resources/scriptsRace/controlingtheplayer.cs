using UnityEngine;

public class Controlingtheplayer : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    public bool TouchPlayer;
    public float MaxSpeed, Acc, LowestSpeed, inerty;
    [SerializeField] Rigidbody2D carRigidbody;


    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();

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
            inerty = 20f;
        }

        else
        {
            inerty = 5f;
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
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, 0, 20 * Time.deltaTime);
        }

        else if (angle < -7 && linearSpeed < 0)
        {
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, 0, 20 * Time.deltaTime);
        }

        else if (angle < -7 && linearSpeed < -angle)
        {
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, -angle, 4f * Time.deltaTime);

        }
        else if (angle >= 7 && linearSpeed < angle)
        {
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, -angle, 4f * Time.deltaTime);
        }

        else if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            // GetComponent<SurfaceEffector2D>().enabled = false;
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, 0, inerty * Time.deltaTime);

        }

        




    }
    
}

