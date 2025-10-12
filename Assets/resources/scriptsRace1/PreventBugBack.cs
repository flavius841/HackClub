using UnityEngine;

public class PreventBugBack : MonoBehaviour
{
    public bool Deactivate2;
    public float stressThreshold = 10f;
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.tag == "player")
    //     {
    //         Deactivate2 = true;
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "player")
    //     {
    //         Deactivate2 = false;
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactForce = collision.relativeVelocity.magnitude;
        if (impactForce > stressThreshold)
        {
            Deactivate2 = true;
        }

        else
        {
            Deactivate2 = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float sustainedForce = collision.relativeVelocity.magnitude;
        if (sustainedForce > stressThreshold)
        {
            Deactivate2 = true;
        }

        else
        {
            Deactivate2 = false;
        }
    }
}
