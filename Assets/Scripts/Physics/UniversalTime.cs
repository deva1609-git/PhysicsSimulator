using UnityEngine;
using TMPro;

public class UniversalTime : MonoBehaviour
{
    public  float TimeScale = 1f;
    public TMP_Text dayCountText;
    public TMP_InputField CalculationsPerSecInput;
    public TMP_InputField TimeScaleInput;
    public float dayCount;
    public float CalculationsPerSec;
    

    private void Start()
    {
        dayCount = 0;
        
        CalculationsPerSec = 1/Time.fixedDeltaTime;
        CalculationsPerSecInput.text = CalculationsPerSec.ToString();
        TimeScaleInput.text = TimeScale.ToString();

    }

    private void FixedUpdate()
    {
        dayCount += Time.fixedDeltaTime * TimeScale;
        if (dayCountText != null) dayCountText.text = "Days Passed: "+ dayCount.ToString("F2");
        
        //SimSpeedText.text = "Simulation Speed: " + TimeScale + " Days/sec";
    }

    public void ApplyChanges()
    {
        float.TryParse(CalculationsPerSecInput.text, out CalculationsPerSec);
        float.TryParse(TimeScaleInput.text, out TimeScale);
        Time.fixedDeltaTime = 1 / CalculationsPerSec;
        CalculationsPerSecInput.text = CalculationsPerSec.ToString();
        TimeScaleInput.text = TimeScale.ToString();
        
    }

}
