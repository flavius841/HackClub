using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] GameObject MenuPrefab;
    public void SettingsMenu()
    {
        GameObject Menu = Instantiate(MenuPrefab);
    }
}
