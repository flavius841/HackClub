using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;




public class FinishLine : MonoBehaviour
{
    [SerializeField] float dellay;
    [SerializeField] CinemachineCamera vcam;
    [SerializeField] ParticleSystem finishParticles;

    public GameObject Menu;
    
    [SerializeField] int Open = 3;
    [SerializeField] int Status;
    [SerializeField] bool Limit;
    [SerializeField] float MaxScale;
    [SerializeField] GameObject Ground1;
    [SerializeField] GameObject Ground2;
    [SerializeField] GameObject Ground3;
    [SerializeField] GameObject Mud;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            finishParticles.Play();
            vcam.Follow = null;
            vcam.LookAt = null;
            Debug.Log("Car reached finish line!");
            Invoke("OpenSettingsMenu", 2f);
            Ground1.GetComponent<CrashScript>().enabled = false;
            Ground2.GetComponent<CrashScript>().enabled = false;
            Ground3.GetComponent<CrashScript>().enabled = false;
            Mud.GetComponent<CrashScript>().enabled = false;
            if (Limit)
            {
                Invoke("ReloadScene", 1);
            }
        }

    }

    public void OpenSettingsMenu()
    {
        Menu.gameObject.SetActive(true);
        Status = Open;
    }

    void Update()
    {
        if (Status == Open && !Limit)
        {
            if (Menu.transform.localScale.magnitude <= MaxScale)
            {
                Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, 200 * Time.deltaTime);
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    
    

    

}

