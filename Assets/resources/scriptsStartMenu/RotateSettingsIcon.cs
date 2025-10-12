using UnityEngine;

public class RotateSettingsIcon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
}
