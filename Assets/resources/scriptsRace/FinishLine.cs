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
    [SerializeField] bool StartCondition;
    [SerializeField] float MaxScale;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            finishParticles.Play();
            vcam.Follow = null;
            vcam.LookAt = null;
            Debug.Log("Car reached finish line!");
            Invoke("OpenSettingsMenu", 2f);
        }

    }

    public void OpenSettingsMenu()
    {
        Menu.gameObject.SetActive(true);
        Status = Open;
    }

    void Update()
    {
        if (Status == Open)
        {
            if (Menu.transform.localScale.magnitude <= MaxScale)
            {
                Menu.transform.localScale += Vector3.one * 3 * Time.deltaTime;
                Menu.transform.Rotate(0, 0, 200 * Time.deltaTime);
            }
        }
    }
    

    

}

