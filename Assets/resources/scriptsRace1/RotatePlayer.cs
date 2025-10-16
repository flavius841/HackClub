using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    Rigidbody2D rb2d;
    public Controlingtheplayer script1; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && !script1.TouchPlayer)
        {
            rb2d.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow) && !script1.TouchPlayer)
        {
            rb2d.AddTorque(-torqueAmount);
        }

    }

}