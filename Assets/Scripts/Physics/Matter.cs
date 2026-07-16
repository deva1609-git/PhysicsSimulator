using System;
using UnityEngine;

public class Matter : MonoBehaviour
{


    public double mass;//SolarMass unit
    public Vector3d position; //AU
    double massKG;

    public Vector3d velocity;// AU / day
    UniversalTime universalTime;
    public float trailLength = 10f;
    float renderScale;
  
    
    

    void Start()
    {
        universalTime = FindAnyObjectByType<UniversalTime>();
        renderScale = FindAnyObjectByType<Constants>().RenderScale;
        
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
}
