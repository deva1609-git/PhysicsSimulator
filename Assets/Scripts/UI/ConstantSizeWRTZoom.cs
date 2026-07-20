using TMPro;
using UnityEngine;

public class ConstantSizeWRTZoom : MonoBehaviour
{
    GameObject cam;
    public float baseScaleFactor;
    private void Start()
    {
        cam = FindAnyObjectByType<CameraMove>().gameObject;
        
    }
    private void LateUpdate()
    {
        float distance = Vector3.Distance(cam.transform.position, gameObject.transform.position);
        transform.localScale = Vector3.one * distance * baseScaleFactor;

    }
}
