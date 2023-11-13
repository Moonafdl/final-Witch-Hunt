using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.TransformPoint( new Vector3(0,5,-10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
