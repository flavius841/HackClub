using UnityEngine;

public class CarManagerScript : MonoBehaviour
{
    void Start()
    {
        if (ChooseCar.Instance.SelectedCar == 1)
        {
            // Activate Formula Car
            transform.GetChild(0).gameObject.SetActive(true);
        }

        else if (ChooseCar.Instance.SelectedCar == 2)
        {
            // Activate Monster Truck
            transform.GetChild(1).gameObject.SetActive(true);
        }

        else if (ChooseCar.Instance.SelectedCar == 4)
        {
            // Activate Rally Car
            transform.GetChild(3).gameObject.SetActive(true);
        }

        else
        {
            // Activate Normal Car
            transform.GetChild(2).gameObject.SetActive(true);
        }



    }
    
    // void Update()
    // {
    //     Debug.Log("ChooseCar instance: " + ChooseCar.Instance);
    //     Debug.Log("SelectedCar: " + ChooseCar.Instance.SelectedCar);

    // }
    
    
    


}
