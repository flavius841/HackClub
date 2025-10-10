using UnityEngine;

public class weels : MonoBehaviour
{

    [SerializeField] float ypos, xpos;
    [SerializeField] Transform indicator;       
    public Vector3 worldOffset;

    void Update()
    {
        
        
        transform.rotation = indicator.transform.rotation;
        



        //transform.position =  new Vector3(indicator.position.x + xpos, transform.position.y, 0);
    }
}
