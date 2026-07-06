using UnityEngine;

public class orbit : MonoBehaviour
{
    public GameObject ObjectToOrbit;
    public float OrbitalVelocity;
    public Vector3 OrbitalRadius;

    
    void Start()
    {
        OrbitalVelocity = Mathf.Sqrt(ObjectToOrbit.GetComponent<Matter>().mass / Vector3.Distance(transform.position, ObjectToOrbit.transform.position));
        OrbitalRadius = transform.position - ObjectToOrbit.transform.position;
        Vector3 TangentialVelocity = Vector3.Cross(OrbitalRadius.normalized, Vector3.up) * OrbitalVelocity;
        gameObject.GetComponent<Matter>().velocity += TangentialVelocity;
    }
}
