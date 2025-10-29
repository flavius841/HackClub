using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject MonsterTruck;
    [SerializeField] GameObject NormalCar;
    [SerializeField] GameObject RallyCar;
    public static ChooseCar Instance;
    public int SelectedCar;
    [SerializeField] GameObject ChooseCarButtonPrefab;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Camera;
    private GameObject FormulaCarInstance;
    private GameObject MonsterTruckInstance;
    private GameObject NormalCarInstance;
    private GameObject RallyCarInstance;
    void Awake()
    {
        GameObject CanvasInstanece = Instantiate(Canvas);
        GameObject chooseCarButton = Instantiate(ChooseCarButtonPrefab, CanvasInstanece.transform);

        // Make this object persistent and create a Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        GameObject CameraInstance = Instantiate(Camera);

        FormulaCarInstance = Instantiate(FormulaCar);
        MonsterTruckInstance = Instantiate(MonsterTruck);
        NormalCarInstance = Instantiate(NormalCar);
        RallyCarInstance = Instantiate(RallyCar);

        
    }

    public void SelectCar()
    {
        if (FormulaCarInstance.transform.position.x == 0)
        {
            SelectedCar = 1;
        }

        else if (MonsterTruckInstance.transform.position.x == 0)
        {
            SelectedCar = 2;
        }

        else if (NormalCarInstance.transform.position.x == 0)
        {
            SelectedCar = 3;
        }

        else if (RallyCarInstance.transform.position.x == 0)
        {
            SelectedCar = 4;
        }

        Invoke("LoadStartMenu", 1f);
    }

    public void LoadStartMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


}
