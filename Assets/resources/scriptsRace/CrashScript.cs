using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashScript : MonoBehaviour
{
    private SurfaceEffector2D surfaceEffector;
    public bool TouchHead;
    [SerializeField] float dellay;
    void Start()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            TouchHead = true;
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
