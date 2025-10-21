using UnityEngine;

public class RaceSettings : MonoBehaviour
{
    public GameObject Menu;
    [SerializeField] bool StatusBool;
    [SerializeField] int Open = 3;
    [SerializeField] int Close = 4;
    [SerializeField] int Status;
    [SerializeField] bool StartCondition;
    [SerializeField] float MaxScale;

    public void QuitLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void InvokeQuitLevel()
    {
        Invoke("QuitLevel", 1f);
    }

    public void OpenSettingsMenu()
    {
        Menu.gameObject.SetActive(true);

    }
    public void CloseSettingsMenu()
    {
        Menu.gameObject.SetActive(false);

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

    public void LoadLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
    
    public void InvokeLoadeLevel2()
    {
        Invoke("LoadLevel2", 1f);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Status == Open)
        {
            OpenSettingsMenu();
            if (Menu.transform.localScale.magnitude <= MaxScale)
            {
                Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, 200 * Time.deltaTime);
            }

            StartCondition = true;
        }

        if (Status == Close && StartCondition)
        {
            if (Menu.transform.localScale.magnitude >= 1f)
            {
                Menu.transform.localScale -= Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, -200 * Time.deltaTime);
            }
            else
            {
                CloseSettingsMenu();
                Menu.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
            }



        }
        
    }
}
