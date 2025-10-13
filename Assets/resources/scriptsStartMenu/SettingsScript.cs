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
    [SerializeField] int Opened = 2;
    [SerializeField] int Closed = 1;

    void Start()
    {
        
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
            Timer = 0;
        }

        if (Status == Close && StatusBool)
        {
            Status = Open;
            Timer = 0;
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
            if (Timer <= 1.7f)
            {
                Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, 200 * Time.deltaTime);
            }
            
            
        }

        if (Status == Close)
        {
            if (Timer <= 1.7f)
            {
                Menu.transform.localScale -= Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, -200 * Time.deltaTime);
            }
            else
            {
                CloseSettingsMenu();
            }
            
        }

        Timer = Timer + Time.deltaTime * Speed;

        Debug.Log(Status);



        
    }

}
