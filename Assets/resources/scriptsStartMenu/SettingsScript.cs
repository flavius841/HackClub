using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{

    public GameObject Menu;

    [SerializeField] float Xpos, Ypos;

    [SerializeField] int Status;
    [SerializeField] bool StatusBool;
    [SerializeField] int Open = 3;
    [SerializeField] int Close = 4;
    [SerializeField] bool StartCondition;
    [SerializeField] float MaxScale;
    [SerializeField] float BigerMaxScale;
    [SerializeField] bool IsMaxScaleSet = false;
    [SerializeField] bool IsBigerMaxScaleSet = false;

    [SerializeField] TextMeshProUGUI ExtrasText;
    [SerializeField] TextMeshProUGUI QuitButtonText;
    [SerializeField] TextMeshProUGUI ExtrasButtonText;
    [SerializeField] bool StartExtrasPreparetions = false;
    [SerializeField] Button ExtrasButton;


    //MaxScale = 6.154472f;


    void Start()
    {
        StartCondition = false;
        ExtrasButton.GetComponent<Button>();
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

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Game is closed");
    }

    public void InvokeCloseGAme()
    {
        Invoke("CloseGame", 1f);
    }

    public void OpenExtras()
    {
        ExtrasText.gameObject.SetActive(true);
        QuitButtonText.gameObject.SetActive(false);
        ExtrasButtonText.gameObject.SetActive(false);
        ExtrasButton.enabled = false;
        StartExtrasPreparetions = true;
    }

    public void CloseExtras()
    {
        ExtrasText.gameObject.SetActive(false);
        QuitButtonText.gameObject.SetActive(true);
        ExtrasButtonText.gameObject.SetActive(true);
        ExtrasButton.enabled = true;
        StartExtrasPreparetions = false;
    }

    public void InvokeOpenExtras()
    {
        Invoke("OpenExtras", 1f);
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
                CloseExtras();
                Menu.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
            }



        }

        if (StartExtrasPreparetions)
        {
            OpenExtras();

            if (Menu.transform.localScale.magnitude <= BigerMaxScale && Status == Open)
            {
                Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
            }

            if (Menu.transform.eulerAngles.z >= 0.5f && Menu.transform.eulerAngles.z <= 179.5f)
            {
                Menu.transform.Rotate(0, 0, -100 * Time.deltaTime);
            }
            
            if (Menu.transform.eulerAngles.z > 179.5f && Menu.transform.eulerAngles.z <= 359.5f)
            {
                Menu.transform.Rotate(0, 0, 100 * Time.deltaTime);
            }
    
        }

        
    }

}
