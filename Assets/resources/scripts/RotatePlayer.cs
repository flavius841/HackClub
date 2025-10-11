using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    Rigidbody2D rb2d;
    public float rotationSpeed;
    public bool TouchGround;
  

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            TouchGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            TouchGround = true;
        }
    }
    
    void  FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && !TouchGround)
        {
            Debug.Log("Left torque applied");
            //transform.Rotate(0, 0, torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation + rotationSpeed * Time.fixedDeltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow) && !TouchGround)
        {
            Debug.Log("rIGHT torque applied");
            //transform.Rotate(0, 0, -torqueAmount, Space.World);
            rb2d.MoveRotation(rb2d.rotation - rotationSpeed * Time.fixedDeltaTime);
        }

        foreach (Transform child in transform)
        {
            child.rotation = transform.rotation;
        } 
        
    }
}