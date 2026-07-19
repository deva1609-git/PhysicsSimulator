using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    public GameObject focusedObject;
    public float rotateSpeed = 0.5f;
    public float minScrollDistance;
    public float maxScrollDistance = 5000000;
    public float minPitch = -80f;
    public float maxPitch = 80f;
    public float zoomAcceleration = 4000f;
    public float zoomDamping = 3f;
    float zoomVelocity;

    Matter focusedMatter;
    float pitch = 0f;

    void Start()
    {
        focusedMatter = focusedObject.GetComponent<Matter>();
        
    }

    void Update()
    {
        transform.LookAt(focusedObject.transform);
        MoveCam();
    }

    void MoveCam()
    {
        var mouse = Mouse.current;

        //Mouse Orbit Thing
        if (mouse.leftButton.isPressed)
        {
            float deltaX = mouse.delta.x.ReadValue();
            float deltaY = mouse.delta.y.ReadValue();

            transform.RotateAround(focusedObject.transform.position, Vector3.up, deltaX * rotateSpeed);

            float pitchDelta = deltaY * rotateSpeed;
            //pitchDelta = Mathf.Clamp(pitch + pitchDelta, minPitch, maxPitch) - pitch;
            pitch += pitchDelta;
            transform.RotateAround(focusedObject.transform.position, transform.right, pitchDelta);
        }

        //Scroll to Zoom in and out part
        float scroll = mouse.scroll.ReadValue().y;
        zoomVelocity += -scroll * zoomAcceleration * Time.deltaTime;
        zoomVelocity *= Mathf.Exp(-zoomDamping * Time.deltaTime);
        minScrollDistance = (float)focusedMatter.Radius + 2;

        Vector3 direction = (transform.position - focusedObject.transform.position).normalized;
        float distance = Vector3.Distance(transform.position, focusedObject.transform.position);
        distance += zoomVelocity * Time.deltaTime;
        distance = Mathf.Clamp(distance, minScrollDistance, maxScrollDistance);
        transform.position = focusedObject.transform.position + direction * distance;
        //if (Mathf.Abs(zoomVelocity) > 0.0001f)
        //{
        //}
    }
}