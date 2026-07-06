using UnityEngine;

public class Matter : MonoBehaviour
{


    public float mass;

    public Vector3 velocity;
    float timeScale;
    public float trailLength = 10f;
    

    void Awake()
    {
        timeScale = FindAnyObjectByType<UniversalTime>().TimeScale;
    }
    public void ApplyForce(Vector3 force)
    {
        Vector3 acceleration = force / mass;
        velocity += acceleration * Time.fixedDeltaTime;
        
    }
    void FixedUpdate()
    {
        transform.position += velocity * Time.fixedDeltaTime * timeScale;
        SetTrailTime();

        
    }

    //SETTING TRAIL LENGTH
    void SetTrailTime()
    {
        float trailTime = trailLength / velocity.magnitude;
        gameObject.GetComponent<TrailRenderer>().time = trailTime;
        
    }




}
