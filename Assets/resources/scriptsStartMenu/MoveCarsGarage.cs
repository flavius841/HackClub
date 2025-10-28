using UnityEngine;

public class MoveCarsGarage : MonoBehaviour
{
    [SerializeField] bool Towards;
    [SerializeField] bool Back;
    [SerializeField] bool Step2;
    [SerializeField] float MoveSpeed;
    [SerializeField] float PosX;
    [SerializeField] float MaxPosX;
    [SerializeField] float MinPosX;


    public void MoveTowards()
    {
        Towards = true;
        Back = false;
        MaxPosX = transform.position.x + 15f;
    }

    public void MoveBack()
    {
        Back = true;
        Towards = false;
        MinPosX = transform.position.x - 15f;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Towards)
        {
            
            if (PosX >= MaxPosX + 3)
            {
                Step2 = true;
            }

            else if (!Step2)
            {
                PosX = Mathf.MoveTowards(transform.position.x, MaxPosX + 3, MoveSpeed * Time.deltaTime);
            }

            if (Step2)
            {
                PosX = Mathf.MoveTowards(transform.position.x, MaxPosX, MoveSpeed / 2 * Time.deltaTime);
                if (PosX <= MaxPosX)
                {
                    Towards = false;
                    Step2 = false;
                }
            }
            
            transform.position = new Vector3(PosX, transform.position.y, transform.position.z);
        }

        if (Back)
        {
            PosX = Mathf.MoveTowards(transform.position.x, MinPosX, MoveSpeed * Time.deltaTime);
            transform.position = new Vector3(PosX, transform.position.y, transform.position.z);
            if (PosX <= MinPosX)
            {
                Towards = false;
            }
        }
        
    }
}
