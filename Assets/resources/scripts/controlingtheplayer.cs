using UnityEngine;

public class Controlingtheplayer : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    public bool TouchPlayer;
    public float MaxSpeed, Acc, LowestSpeed;

    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "wheel1" || other.tag == "wheel2")
        {
            TouchPlayer = true;
        }
    }
    
   

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "wheel1" || other.tag == "wheel2")
        {
            TouchPlayer = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && TouchPlayer)
        {
            GetComponent<SurfaceEffector2D>().enabled = true;
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, LowestSpeed, Acc * Time.deltaTime);

        }


        if (Input.GetKey(KeyCode.RightArrow) && TouchPlayer)
        {
            GetComponent<SurfaceEffector2D>().enabled = true;
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, MaxSpeed, Acc * Time.deltaTime);

        }

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SurfaceEffector2D>().enabled = false;
            surfaceEffector.speed = Mathf.MoveTowards(surfaceEffector.speed, 0, Acc * Time.deltaTime);
        }

        




    }
    
}

