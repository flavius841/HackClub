using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    //[SerializeField] float torqueAmount;
    Rigidbody2D rb2d;
    public float LeftRotationSpeed, RightRotationSpeed;
    //public bool TouchGround;

    public TouchGroundFrontWheel script1;
    public TouchGroundBackWheel script2;
    public PreventBugFront script3;
    public PreventBugBack script4;
    [SerializeField] public bool ResetRot;
    public float Rotvalue;

  

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.MoveRotation(Rotvalue);

        foreach (Transform child in transform)
        {
            child.rotation = transform.rotation;
        }
    }



    void FixedUpdate()
    {
        if (script1.Rotate1 && script2.Rotate2 && ResetRot)
        {
            rb2d.MoveRotation(Rotvalue);
            ResetRot = false;
        }
        
        if (script3.Deactivate1 || script4.Deactivate2)
        {
            rb2d.MoveRotation(Rotvalue);
        }

        Rotate();

        if (!script1.Rotate1 && !script2.Rotate2)
        {
            ResetRot = true;
        }

        foreach (Transform child in transform)
        {
            child.rotation = transform.rotation;
        }

        
    }
    
    public void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && script1.Rotate1 && script2.Rotate2)
        {
            Debug.Log("Left torque applied");
            //transform.Rotate(0, 0, torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation + LeftRotationSpeed * Time.fixedDeltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow) && script1.Rotate1 && script2.Rotate2)
        {
            Debug.Log("rIGHT torque applied");
            //transform.Rotate(0, 0, -torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation - RightRotationSpeed * Time.fixedDeltaTime);
        }

        

    }
}