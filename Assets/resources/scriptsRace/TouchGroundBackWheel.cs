using UnityEngine;

public class TouchGroundBackWheel : MonoBehaviour
{

    public bool Rotate2;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Rotate2 = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Rotate2 = false;
        }
    }

}
