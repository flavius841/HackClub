using UnityEngine;
using Unity.Cinemachine;

public class SetCamera : MonoBehaviour
{
    [SerializeField] CinemachineCamera vcam;
    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject MonsterTruck;
    
    void Start()
    {
        if (FormulaCar.activeInHierarchy)
        {
            vcam.Follow = FormulaCar.transform;
            vcam.LookAt = FormulaCar.transform;
        }

        if (MonsterTruck.activeInHierarchy)
        {
            vcam.Follow = MonsterTruck.transform;
            vcam.LookAt = MonsterTruck.transform;
        }
    }

}
