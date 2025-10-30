using UnityEngine;
using UnityEngine.UI;

public class InstatiateScene : MonoBehaviour
{
    public Button choosecarButton;          // Reference to the UI Button
    public ChooseCar chooseCar;  // Reference to the object that has the function

    void Start()
    {
        // Option 1: Use lambda expression
        choosecarButton.onClick.AddListener(() => chooseCar.SelectCar());

        // Option 2: Direct method reference (if no parameters)
        // myButton.onClick.AddListener(myFunctions.DoSomething);
    }
    
}
