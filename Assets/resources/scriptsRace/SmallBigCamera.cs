using UnityEngine;
using Unity.Cinemachine;

public class SmallBigCamera : MonoBehaviour
{
    [SerializeField] CinemachineCamera vcam;
    [SerializeField] bool Small;
    [SerializeField] bool StartProcess;
    [SerializeField] float newOrthoSize;
    [SerializeField] float Speed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            StartProcess = true;
        }

    }
    void Update()
    {
        newOrthoSize = vcam.Lens.OrthographicSize;

        if (StartProcess)
        {
            if (Small)
            {
                ChangeLens(44f);
            }

            else
            {
                ChangeLens(28.6f);
            }

        }

    }
    
    public void ChangeLens(float FinalValue)
    {
        var lens = vcam.Lens;
        newOrthoSize = Mathf.MoveTowards(newOrthoSize, FinalValue, Speed * Time.deltaTime);
        lens.OrthographicSize = newOrthoSize;
        vcam.Lens = lens;

        if (newOrthoSize >= FinalValue - 0.001f && Small)
        {
            StartProcess = false;
        }
        
        else if (newOrthoSize <= FinalValue && !Small)
        {
            StartProcess = false;
        }
    }
}
