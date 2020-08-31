using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Follow camera is a class that handle object to follow the camera basically.
// And it use physics to calculate a smooth hinge/join between tho.
public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        // only using these 3 line, is useful for side platform game cameras. 
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
