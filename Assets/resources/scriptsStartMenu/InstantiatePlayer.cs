using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float Timer;
    [SerializeField] float Speed;
    [SerializeField] GameObject RaceCarPrefab;
    [SerializeField] GameObject NormalCarPrefab;
    [SerializeField] GameObject MonsterCarPrefab;
    [SerializeField] GameObject RallyCarPrefab;
    [SerializeField] int ID;
    private SurfaceEffector2D surfaceEffector;
    float randomSpeed;
    [SerializeField] int RandomCar;
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

            RandomCar = Random.Range(1, 5);
            randomSpeed = Random.Range(20f, 70f);
            surfaceEffector.speed = randomSpeed;

            if (RandomCar == 1)
            {
                GameObject Car = Instantiate(RallyCarPrefab);
                Car.transform.name = ID.ToString();
            }

            else if (RandomCar == 2)
            {
                GameObject Car = Instantiate(MonsterCarPrefab);
                Car.transform.name = ID.ToString();
            }

            else if (RandomCar == 3)
            {
                GameObject Car = Instantiate(NormalCarPrefab);
                Car.transform.name = ID.ToString();
            }

            else
            {
                GameObject Car = Instantiate(RaceCarPrefab);
                Car.transform.name = ID.ToString();
            }
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
