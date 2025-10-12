using UnityEngine;

public class CarSuport : MonoBehaviour
{
    [SerializeField] float ypos, xpos;
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    public TouchGroundFrontWheel script1;
    public TouchGroundBackWheel script2;
    public PreventBugFront script3;
    public PreventBugBack script4;
    private CapsuleCollider2D capsuleCollider;



    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        if (!script1.Rotate1 || !script2.Rotate2 || script3.Deactivate1 || script4.Deactivate2)
        {
            capsuleCollider.enabled = false;
        }

        else
        {
            capsuleCollider.enabled = true;
        }

        capsuleCollider.offset = new Vector2(0.4f, 15.83f);




        Vector2 direction = target1.position - target2.position;
        Vector2 midPoint = (target1.position + target2.position) / 2f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = new Vector3(midPoint.x + xpos, midPoint.y + ypos, 0);
        
        

    }
}