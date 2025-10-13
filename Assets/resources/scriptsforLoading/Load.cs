using UnityEngine;

public class Load : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    public float Timer;
    public float Speed;
    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();
        surfaceEffector.speed = 1f;


    }

    void Update()
    {
        Timer = Timer + Time.deltaTime * Speed;


        if (Timer >= 6f && Timer <= 8f)
        {
            surfaceEffector.speed = 5f;
        }

        if (Timer >= 8f)
        {
            surfaceEffector.speed = -10f;
        }
        
        if (Timer >= 9f)
        {
            surfaceEffector.speed = 4f;
        }
    }
}
