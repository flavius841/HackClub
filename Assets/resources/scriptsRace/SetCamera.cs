using UnityEngine;
using Unity.Cinemachine;

public class SetCamera : MonoBehaviour
{
    [SerializeField] CinemachineCamera vcam;
    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject MonsterTruck;
    [SerializeField] GameObject NormalCar;
    [SerializeField] GameObject RallyCar;
    
    void Start()
    {
        if (FormulaCar.activeInHierarchy)
        {
            vcam.Follow = FormulaCar.transform;
            vcam.LookAt = FormulaCar.transform;
        }

        else if (MonsterTruck.activeInHierarchy)
        {
            vcam.Follow = MonsterTruck.transform;
            vcam.LookAt = MonsterTruck.transform;
        }

        else if (NormalCar.activeInHierarchy)
        {
            vcam.Follow = NormalCar.transform;
            vcam.LookAt = NormalCar.transform;
        }

        else
        {
            vcam.Follow = RallyCar.transform;
            vcam.LookAt = RallyCar.transform;
        }
    }

}
