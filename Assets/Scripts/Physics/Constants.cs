    using UnityEngine;

public class Constants : MonoBehaviour
{
    //Keeping our dimesional units as [M,L,T] = [SolarMass, AU, Days]
    public const double AU = 1.496e+11; //meters
    public const double SolarMass = 1.988e+30; //kg
    public const double Days = 86400; //seconds
    public const double G = 2.959122e-4; // AU^3 SolarMass^-1 Day^-2
    public float RenderScale = 100f;

}
