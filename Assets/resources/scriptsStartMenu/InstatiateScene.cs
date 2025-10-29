using UnityEngine;

public class InstatiateScene : MonoBehaviour
{
    [SerializeField] GameObject ChooseCarManagerPrefab;
    void Start()
    {
        GameObject chooseCarManager = Instantiate(ChooseCarManagerPrefab);
    }

    
}
