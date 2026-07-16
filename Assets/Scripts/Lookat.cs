using UnityEngine;

public class Lookat : MonoBehaviour
{
    public GameObject ObjectToLookAt;
    void Update()
    {
        transform.LookAt(ObjectToLookAt.transform);
    }
}
