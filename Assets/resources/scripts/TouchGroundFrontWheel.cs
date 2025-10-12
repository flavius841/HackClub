using UnityEngine;

public class TouchGroundFrontWheel : MonoBehaviour
{

    public bool Rotate1;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Rotate1 = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Rotate1 = false;
        }
    }



}
