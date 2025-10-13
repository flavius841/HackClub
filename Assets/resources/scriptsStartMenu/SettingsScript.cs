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
        Timer = 0;
        Status = Open;

    }

    public void CloseSettingsMenu()
    {
        Menu.gameObject.SetActive(false);
        Menu.transform.position = new Vector3(Xpos, Ypos, 0);
        Timer = 0;
        Status = Close;

    }

    public void SettingsMenu()
    {
        if (Status == Open)
        {
            Status = Opened;
        }

        if (Status == Close)
        {
            Status = Closed;
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
        if (Status == Closed)
        {
            OpenSettingsMenu();
        }

        if (Status == Opened)
        {
            CloseSettingsMenu();
        }

        Timer = Timer + Time.deltaTime * Speed;
        if (Timer <= 1.7f && Status == Open)
        {
            Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
            Menu.transform.Rotate(0, 0, 200 * Time.deltaTime);
        }

        if (Timer <= 1.7f && Status == Close)
        {
            Menu.transform.localScale -= Vector3.one * 3 * Time.deltaTime;
            Menu.transform.Rotate(0, 0, -200 * Time.deltaTime);
        }
    }

}
