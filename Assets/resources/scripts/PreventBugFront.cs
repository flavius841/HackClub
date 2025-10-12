using UnityEngine;

public class PreventBugFront : MonoBehaviour
{
    public bool Deactivate1;

    public float stressThreshold = 10f;
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.tag == "Ground")
    //     {
    //         Deactivate1 = true;
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Ground")
    //     {
    //         Deactivate1 = false;
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactForce = collision.relativeVelocity.magnitude;
        if (impactForce > stressThreshold)
        {
            Deactivate1 = true;
        }

        else
        {
            Deactivate1 = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float sustainedForce = collision.relativeVelocity.magnitude;
        if (sustainedForce > stressThreshold)
        {
            Deactivate1 = true;
        }

        else
        {
            Deactivate1 = false;
        }
    }

}
