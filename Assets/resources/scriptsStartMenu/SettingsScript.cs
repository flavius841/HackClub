using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject MenuPrefab;
    public GameObject Menu;
    public Transform Canvass;
    [SerializeField] float Xpos, Ypos;
    [SerializeField] float Timer;
    [SerializeField] float Speed;
    [SerializeField] int Status;
    [SerializeField] bool StatusBool;
    [SerializeField] int Open = 3;
    [SerializeField] int Close = 4;
    [SerializeField] bool StartCondition;
    [SerializeField] float MaxScale;
    [SerializeField] bool IsMaxScaleSet = false;
    [SerializeField] bool IsMinScaleSet = false;
    //MaxScale = 6.154472f;


    void Start()
    {
        StartCondition = false;
    }

    public void OpenSettingsMenu()
    {
        Menu.gameObject.SetActive(true);
        Menu.transform.position = new Vector3(Xpos, Ypos, 0);
        
    }

    public void CloseSettingsMenu()
    {
        Menu.gameObject.SetActive(false);
        Menu.transform.position = new Vector3(Xpos, Ypos, 0);

    }

    public void SettingsMenu()
    {
        StatusBool = !StatusBool;

        if (Status == Open && !StatusBool)
        {
            Status = Close;

              
        }

        if (Status == Close && StatusBool)
        {
            Status = Open;
        }

        
    }

    public void LoadLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void InvokeLoadeLevel1()
    {
        Invoke("LoadLevel1", 1f);
    }
    
    void Update()
    {
        if (Status == Open)
        {
            OpenSettingsMenu();
            if (Timer <= 1.7f && !IsMaxScaleSet)
            {
                Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, 200 * Time.deltaTime);
            }

            StartCondition = true;

            if (Menu.transform.localScale.magnitude > MaxScale)
            {
                IsMaxScaleSet = true;
            }

            else
            {
                IsMaxScaleSet = false;
            }
            
             Timer = 0;
            
        }

        if (Status == Close && StartCondition)
        {
            if (Timer <= 1.7f && !IsMinScaleSet)
            {
                Menu.transform.localScale -= Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, -200 * Time.deltaTime);
            }
            else
            {
                CloseSettingsMenu();
            }

            if (Menu.transform.localScale.magnitude < 1f)
            {
                IsMinScaleSet = true;
            }
            else
            {
                IsMinScaleSet = false;  
            }
            
            Timer = 0;         

        }
        

        Timer = Timer + Time.deltaTime * Speed;




        
    }

}
