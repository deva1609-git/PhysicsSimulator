using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Matter : MonoBehaviour
{


    public double mass;//SolarMass unit
    public Vector3d position; //AU
    double massKG;
    public double Radius; //AU
    public string PlanetName;

    public Vector3d velocity;// AU / day
    UniversalTime universalTime;
    public float trailLength = 10f;
    float renderScale;
    CameraMove camMove;
    GameObject NameTextCanvasPrefab;
    
    

    void Start()
    {
        universalTime = FindAnyObjectByType<UniversalTime>();
        renderScale = FindAnyObjectByType<Constants>().RenderScale;
        camMove = FindAnyObjectByType<CameraMove>();
        PlanetName = gameObject.name;

        GameObject NameTextCanvasPrefab = Resources.Load<GameObject>("Prefabs/NameTextCanvas");
        GameObject labelInstance = Instantiate(NameTextCanvasPrefab, transform.position, Quaternion.identity, gameObject.transform);
        TMP_Text NameText = labelInstance.GetComponentInChildren<TMP_Text>();
        NameText.text = PlanetName;
        ConstraintSource Camsource = new ConstraintSource();
        Camsource.sourceTransform = camMove.gameObject.transform;
        Camsource.weight = 1f;
        labelInstance.GetComponentInChildren<LookAtConstraint>().AddSource(Camsource);
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
