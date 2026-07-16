using UnityEngine;
using System.Collections.Generic;

public class MatterGravity : MonoBehaviour
{

    List<Matter> AllBodies = new List<Matter>();
    UniversalTime universalTime;
    
    void Start()
    {
        AllBodies = new List<Matter>(FindObjectsByType<Matter>());
        universalTime = FindAnyObjectByType<UniversalTime>();
        
    }



    Vector3d GetGravitationalForce(Matter body1, Matter body2)
    {
        double distance = Vector3d.Distance(body1.position, body2.position);//AU
        //Debug.Log("Pairings:" + body1.name + " vs " + body2.name + " Distance: " + distance);
        double CalculatedForce = (body1.mass * body2.mass * Constants.G)/(distance*distance); 
        Vector3d direction = (body2.position - body1.position).Normalized;
        return direction * CalculatedForce;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        for (int i = 0; i < AllBodies.Count; i++)
        {
            

            for (int j = i + 1; j < AllBodies.Count; j++)
            {
                Vector3d calculatedForce1 = GetGravitationalForce(AllBodies[i], AllBodies[j]);
                Vector3d calculatedForce2 = -calculatedForce1;

                AllBodies[i].ApplyForce(calculatedForce1);
                AllBodies[j].ApplyForce(calculatedForce2);
            }
        }
    }

}
