using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject MenuPrefab;
    public GameObject Menu;
    public Transform Canvass;
    [SerializeField] float Xpos, Ypos;
    [SerializeField] float Timer;
    [SerializeField] float Speed;
    void Start()
    {
    }

    public void SettingsMenu()
    {
        Menu = Instantiate(MenuPrefab, Canvass);
        Menu.transform.position = new Vector3(Xpos, Ypos, 0);
        Menu.transform.localScale += Vector3.one * Time.deltaTime;
        Timer = 0;

    }

    public void LoadLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void InvokeLoadeLevel1()
    {
        Invoke("LoadLevel1", 1f);
    }
    
    void Update()
    {
        Timer = Timer + Time.deltaTime * Speed;
        if (Timer <= 1.7f)
        {
            Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
            Menu.transform.Rotate(0, 0, 200 * Time.deltaTime);
        }
    }

}
