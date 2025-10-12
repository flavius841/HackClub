using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    //[SerializeField] float torqueAmount;
    Rigidbody2D rb2d;
    public float LeftRotationSpeed, RightRotationSpeed;
    //public bool TouchGround;

    public TouchGroundFrontWheel script1;
    public TouchGroundBackWheel script2;

  

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    void  FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && script1.Rotate)
        {
            Debug.Log("Left torque applied");
            //transform.Rotate(0, 0, torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation + LeftRotationSpeed * Time.fixedDeltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow) && script1.Rotate)
        {
            Debug.Log("rIGHT torque applied");
            //transform.Rotate(0, 0, -torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation - RightRotationSpeed * Time.fixedDeltaTime);
        }

        foreach (Transform child in transform)
        {
            child.rotation = transform.rotation;
        } 
        
    }
}