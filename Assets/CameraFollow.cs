using UnityEngine;

//this class follows the player as they move accross the plaform
public class CameraFollow : MonoBehaviour
{
    //variables
    public Transform target; 
    public float smoothSpeed = 0.1f; 

    private Vector3 offset; 

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
