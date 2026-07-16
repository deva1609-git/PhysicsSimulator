using UnityEngine;
using System;

public class orbit : MonoBehaviour
{
    
    public Matter ObjectToOrbit;
    public double OrbitalVelocity;
    public Vector3d OrbitalRadius;
    Matter thisMatter;
    public double OrbitTime;
    UniversalTime universalTime;
    public bool SetTrailLengthDueToOrbit = true;



    void Start()
    {
        thisMatter = gameObject.GetComponent<Matter>();
        ObjectToOrbit = ObjectToOrbit.GetComponent<Matter>();
        universalTime = FindAnyObjectByType<UniversalTime>();

        OrbitalVelocity = Math.Sqrt((ObjectToOrbit.mass * Constants.G) / Vector3d.Distance(thisMatter.position, ObjectToOrbit.position));
        OrbitalRadius = thisMatter.position - ObjectToOrbit.position;
        Vector3d TangentialVelocity = Vector3d.Cross(OrbitalRadius.Normalized, Vector3.up) * OrbitalVelocity;

        gameObject.GetComponent<Matter>().velocity += TangentialVelocity;

        OrbitTime = (2 * Math.PI * OrbitalRadius.Magnitude) / OrbitalVelocity;

        Debug.Log(OrbitalVelocity.ToString());
    }
    private void FixedUpdate()
    {
        if(universalTime.dayCount == OrbitTime)
        {
            Debug.Log(gameObject.name + ": " + universalTime.dayCount);
        }
        if (SetTrailLengthDueToOrbit)
        {
            thisMatter.trailLength = (float)(2 * Math.PI * OrbitalRadius.Magnitude);
        }

    }
}
