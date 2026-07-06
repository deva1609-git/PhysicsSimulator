using UnityEngine;

using System.Collections.Generic;

public class MatterGravity : MonoBehaviour
{

    List<Matter> AllBodies = new List<Matter>();
    UniversalTime universalTime;
    float timeScale;
    void Start()
    {
        AllBodies = new List<Matter>(FindObjectsByType<Matter>());
        universalTime = FindAnyObjectByType<UniversalTime>();
        
    }



    Vector3 GetGravitationalForce(Matter body1, Matter body2)
    {
        float distance = Vector3.Distance(body1.transform.position, body2.transform.position);
        Debug.Log("Pairings:" + body1.name + " vs " + body2.name + " Distance: " + distance);
        float CalculatedForce = body1.mass * body2.mass / Mathf.Pow(distance, 2);
        Vector3 direction = (body2.transform.position - body1.transform.position).normalized;
        return direction * CalculatedForce;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timeScale = universalTime.TimeScale;
        for (int i = 0; i < AllBodies.Count; i++)
        {
            

            for (int j = i + 1; j < AllBodies.Count; j++)
            {
                Vector3 calculatedForce1 = GetGravitationalForce(AllBodies[i], AllBodies[j]);
                Vector3 calculatedForce2 = -calculatedForce1;

                AllBodies[i].ApplyForce(calculatedForce1);
                AllBodies[j].ApplyForce(calculatedForce2);
            }
        }
    }

}
