using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashScript : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    public bool TouchHead;
    [SerializeField] float dellay;
    [SerializeField] GameObject FormulaCar;
    [SerializeField] GameObject NormalCar;
    [SerializeField] GameObject Rallycar;
    [SerializeField] ParticleSystem Blood1;
    [SerializeField] ParticleSystem Blood2;
    [SerializeField] ParticleSystem Blood3;
    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();
        Blood1.Stop();
        Blood2.Stop();
        Blood3.Stop();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            TouchHead = true;

            if (FormulaCar.activeInHierarchy)
            {
                Blood1.Play();
            }

            else if (NormalCar.activeInHierarchy)
            {
                Blood2.Play();
            }

            else if (Rallycar.activeInHierarchy)
            {
                Blood3.Play();
            }
            
            
        }
    }

    void Update()
    {
        if (TouchHead)
        {
            surfaceEffector.speed = 0f;
            Invoke("ReloadScene", dellay);
            
        }

    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
