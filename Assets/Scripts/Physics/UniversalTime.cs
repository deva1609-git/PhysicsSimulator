using UnityEngine;
using TMPro;

public class UniversalTime : MonoBehaviour
{
    public  float TimeScale = 1f;
    public TMP_Text dayCountText;
    public TMP_InputField CalculationsPerSecInput;
    public TMP_InputField simSpeedInput;
    public float dayCount;
    public float CalculationsPerSec;
    

    private void Start()
    {
        dayCount = 0;
        simSpeedInput.text = TimeScale.ToString();
        CalculationsPerSec = 1/Time.fixedDeltaTime;
        CalculationsPerSecInput.text = CalculationsPerSec.ToString("F2");
    }

    private void FixedUpdate()
    {
        dayCount += Time.fixedDeltaTime * TimeScale;
        if (dayCountText != null) dayCountText.text = "Days Passed: "+ dayCount.ToString("F2");
        //SimSpeedText.text = "Simulation Speed: " + TimeScale + " Days/sec";
    }
    public void ChangeSimSpeed()
    {
        float.TryParse(simSpeedInput.text, out TimeScale);
    }
    public void ChangeCalculationsPerSec()
    {
        float.TryParse(CalculationsPerSecInput.text, out CalculationsPerSec);
        Time.fixedDeltaTime = 1 / CalculationsPerSec;
    }

}
