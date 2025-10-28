using UnityEngine;

public class CarManagerScript : MonoBehaviour
{
    void Start()
    {
        int selectedCar = 3; 
        
        if (ChooseCar.Instance != null)
        {
            selectedCar = ChooseCar.Instance.SelectedCar;
        }

        if (selectedCar == 1)
        {
            // Activate Formula Car
            transform.GetChild(0).gameObject.SetActive(true);
        }

        else if (selectedCar == 2)
        {
            // Activate Monster Truck
            transform.GetChild(1).gameObject.SetActive(true);
        }

        else if (selectedCar == 4)
        {
            // Activate Rally Car
            transform.GetChild(3).gameObject.SetActive(true);
        }

        else if (selectedCar == 3)
        {
            // Activate Normal Car
            transform.GetChild(2).gameObject.SetActive(true);
        }



    }
    
    
    

    


}
