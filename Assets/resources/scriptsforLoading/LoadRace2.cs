using UnityEngine;

public class LoadRace2 : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    
    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();
        surfaceEffector.speed = 10f;


    }

    void Update()
    {
        
    }
}
