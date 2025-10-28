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
    [SerializeField] float Timer;


    public void MoveTowards()
    {   
        PosX = transform.position.x;
        if (PosX == 30 && Timer > 0.5f)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
            MaxPosX = -15;
            Timer = 0;
        }

        else if ((PosX == -30 || PosX == -15 || PosX == 0 || PosX == 15) && Timer > 0.5f)
        {
            Towards = true;
            Back = false;
            MaxPosX = transform.position.x + 15f;
            Timer = 0;

        }
    }

    public void MoveBack()
    {
        // Back = true;
        // Towards = false;
        // MinPosX = transform.position.x - 15f;
        // PosX = transform.position.x;

        PosX = transform.position.x;
        if (PosX == -30 && Timer > 0.5f)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
            MinPosX = 15;
            Timer = 0;
        }

        else if ((PosX == -30 || PosX == -15 || PosX == 0 || PosX == 15 || PosX == 30) && Timer > 0.5f)
        {
            Back = true;
            Towards = false;
            MinPosX = transform.position.x - 15f;
            Timer = 0;

        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        Timer += Time.deltaTime;

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
            if (PosX <= MinPosX - 3)
            {
                Step2 = true;
            }

            else if (!Step2)
            {
                PosX = Mathf.MoveTowards(transform.position.x, MinPosX - 3, MoveSpeed * Time.deltaTime);
            }

            if (Step2)
            {
                PosX = Mathf.MoveTowards(transform.position.x, MinPosX, MoveSpeed / 2 * Time.deltaTime);
                if (PosX >= MinPosX)
                {
                    Back = false;
                    Step2 = false;
                }
            }
            
            transform.position = new Vector3(PosX, transform.position.y, transform.position.z);
        }
        
    }
}
