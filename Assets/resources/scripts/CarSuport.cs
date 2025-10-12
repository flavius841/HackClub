using UnityEngine;

public class CarSuport : MonoBehaviour
{
    [SerializeField] float ypos, xpos;
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    public TouchGroundFrontWheel script1;
    public TouchGroundBackWheel script2;
    private CapsuleCollider2D capsuleCollider;



    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        if (!script1.Rotate1 || !script2.Rotate2)
        {
            capsuleCollider.enabled = false;
        }

        else
        {
            capsuleCollider.enabled = true;
        }


        Vector2 direction = target1.position - target2.position;
        Vector2 midPoint = (target1.position + target2.position) / 2f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        transform.position =  new Vector3(midPoint.x + xpos, midPoint.y + ypos, 0);
        

    }
}