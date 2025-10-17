using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;




public class FinishLine : MonoBehaviour
{
    [SerializeField] float dellay;
    [SerializeField] CinemachineCamera vcam;
    [SerializeField] ParticleSystem finishParticles;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Car")
        {
            finishParticles.Play();
            vcam.Follow = null;
            vcam.LookAt = null;
            Debug.Log("Car reached finish line!");
            Invoke("ReloadScene", dellay);
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}

