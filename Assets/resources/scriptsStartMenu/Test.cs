using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject MenuPrefab;
    private GameObject MenuInstance;
    public Transform Canvas;
    [SerializeField] float Xpos, Ypos;
    [SerializeField] float Timer;
    [SerializeField] float Speed = 1f;

    void Update()
    {
        if (MenuInstance != null)
        {
            Timer += Time.deltaTime * Speed;

            if (Timer <= 2.5f)
            {
                MenuInstance.transform.localScale += Vector3.one * Time.deltaTime;
                MenuInstance.transform.Rotate(0, 0, 200 * Time.deltaTime);
            }
        }
    }

    public void SettingsMenu()
    {
        // If a menu already exists, don't spawn another
        if (MenuInstance != null) return;

        // Create a new one
        MenuInstance = Instantiate(MenuPrefab, Canvas);
        MenuInstance.transform.position = new Vector3(Xpos, Ypos, 0);
        MenuInstance.transform.localScale = Vector3.one; // reset size

        // Reset timer each time menu is opened
        Timer = 0f;
    }
}
