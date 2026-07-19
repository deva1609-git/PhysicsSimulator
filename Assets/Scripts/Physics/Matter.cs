using System;
using UnityEngine;

public class Matter : MonoBehaviour
{


    public double mass;//SolarMass unit
    public Vector3d position; //AU
    double massKG;
    public double Radius; //AU

    public Vector3d velocity;// AU / day
    UniversalTime universalTime;
    public float trailLength = 10f;
    float renderScale;
    CameraMove camMove;
  
    
    

    void Start()
    {
        universalTime = FindAnyObjectByType<UniversalTime>();
        renderScale = FindAnyObjectByType<Constants>().RenderScale;
        camMove = FindAnyObjectByType<CameraMove>();
    }

    public void ApplyForce(Vector3d force)
    {
        Vector3d acceleration = force / mass;
        velocity += acceleration * Time.fixedDeltaTime * universalTime.TimeScale;

    }
    void FixedUpdate()
    {
        position += velocity * Time.fixedDeltaTime * universalTime.TimeScale;
        SetTrailTime();
        transform.position = position.ToVector3() * renderScale;
        
        
    }
    void SetTrailTime()
    {
        float trailTime = (float)(trailLength / (velocity.Magnitude* universalTime.TimeScale));
        gameObject.GetComponent<TrailRenderer>().time = trailTime;    
    }

    private void OnMouseDown()
    {
        camMove.focusedObject = gameObject;
    }
}
