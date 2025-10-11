using UnityEngine;

public class weels : MonoBehaviour
{
    //[SerializeField] Transform indicator;
    [SerializeField] Transform target;
   


      

    void Update()
    {
        
        transform.rotation = target.transform.rotation;
        



        //transform.position =  new Vector3(indicator.position.x + xpos, transform.position.y, 0);
    }
}
