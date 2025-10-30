using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject MonsterTruck;
    [SerializeField] GameObject NormalCar;
    [SerializeField] GameObject RallyCar;
    public static ChooseCar Instance;
    public int SelectedCar;
    
    void Awake()
    {
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
    }

    public void SelectCar()
    {
        if (FormulaCar.transform.position.x == 0)
        {
            SelectedCar = 1;
        }

        else if (MonsterTruck.transform.position.x == 0)
        {
            SelectedCar = 2;
        }

        else if (NormalCar.transform.position.x == 0)
        {
            SelectedCar = 3;
        }

        else if (RallyCar.transform.position.x == 0)
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
