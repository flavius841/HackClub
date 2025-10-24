using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    //[SerializeField] float torqueAmount;
    Rigidbody2D rb2d;
    public float LeftRotationSpeed, RightRotationSpeed;
    //public bool TouchGround;

    // public TouchGroundFrontWheel Ground1;
    // public TouchGroundBackWheel Mud;
    // public PreventBugFront script3;
    // public PreventBugBack script4;
    public Controlingtheplayer Ground1;
    public Controlingtheplayer Ground2;
    public Controlingtheplayer Ground3;
    public ControlingThePlayeInTheMud Mud;
    public bool TouchMud;
    //[SerializeField] public bool ResetRot;
    // public float Rotvalue;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mud")
        {
            TouchMud = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Mud")
        {
            TouchMud = false;
        }
    }

  

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.MoveRotation(Rotvalue);

        // foreach (Transform child in transform)
        // {
        //     child.rotation = transform.rotation;
        // }
    }



    void FixedUpdate()
    {
        // if (Ground1.Rotate1 && Mud.Rotate2 && ResetRot)
        // {
        //     rb2d.MoveRotation(Rotvalue);
        //     ResetRot = false;
        // }
        
        // if (script3.Deactivate1 || script4.Deactivate2)
        // {
        //     rb2d.MoveRotation(Rotvalue);
        // }

        Rotate();

        // if (!Ground1.Rotate1 && !Mud.Rotate2)
        // {
        //     ResetRot = true;
        // }

        // foreach (Transform child in transform)
        // {
        //     child.rotation = transform.rotation;
        // }

        
    }
    
    public void Rotate()
    {
        // if (Input.GetKey(KeyCode.LeftArrow) && Ground1.Rotate1 && Mud.Rotate2)
        if (Input.GetKey(KeyCode.LeftArrow) && !Ground1.TouchPlayer && !Ground2.TouchPlayer && !Ground3.TouchPlayer && !Mud.TouchPlayer)
        {
            
            //transform.Rotate(0, 0, torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation + LeftRotationSpeed * Time.fixedDeltaTime);
        }

        //else if (Input.GetKey(KeyCode.RightArrow) && Ground1.Rotate1 && Mud.Rotate2)
        else if (Input.GetKey(KeyCode.RightArrow) && !Ground1.TouchPlayer && !Ground2.TouchPlayer && !Ground3.TouchPlayer && !Mud.TouchPlayer) 
        {
            
            //transform.Rotate(0, 0, -torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation - RightRotationSpeed * Time.fixedDeltaTime);
        }

        

    }
}