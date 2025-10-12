using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float Timer;
    [SerializeField] float Speed;
    [SerializeField] GameObject CarPrefab;
    [SerializeField] int ID;
    private SurfaceEffector2D surfaceEffector;
    float randomSpeed;
    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();
    }
    
    void Update()
    {

        Timer = Timer + Time.deltaTime * Speed;
        if (Timer >= 4)
        {
            Timer = 0;
            ID++;

            randomSpeed = Random.Range(20f, 70f);
            surfaceEffector.speed = randomSpeed;

            GameObject Car = Instantiate(CarPrefab);
            Car.transform.name = ID.ToString();
        }

        if (ID >= 3)
        {
            GameObject obj1 = GameObject.Find("1");
            Destroy(obj1);
            GameObject obj2 = GameObject.Find("2");
            Destroy(obj2);
            ID = 0;
        }

        if (ID >= 1)
        {
            GameObject obj3 = GameObject.Find("3");
            Destroy(obj3);
        }
        
        
    }
}
