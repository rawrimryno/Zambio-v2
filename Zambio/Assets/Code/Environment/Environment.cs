using UnityEngine;
using System.Collections;

public class Environment : MonoBehaviour
{

    private Light Sun;
    public int DayLength; // For Testing
    public int DawnStart = 5;
    public int DayStart = 8;
    public int DuskStart = 17;
    public int NightStart = 20;

    public float initDawnIntensity  = 0.6f;  // FinalNightIntensity
    public float initDayIntensity   = 0.8f;  // FinalDawnIntensity
    public float initDuskIntensity  = 0.6f;  // Final Day Intensity
    public float initNightIntensity = 0.6f; // FinalDuskIntensity

    public Color initDawnColor;
    public Color initDayColor;
    public Color initDuskColor;
    public Color initNightColor;

    public float initTime = 8;  // This is what time it is when our game starts
                                  //  This shouldn't change, but make it public to tweak

    private int numDays = 100;
    private float dt;
    private Quaternion initSunRotation, finalSunRotation;
    private Vector3 SunRotationAxis;




    // Use this for initialization
    void Start()
    {
        initSunRotation = Quaternion.Euler(Vector3.zero);
        finalSunRotation = Quaternion.Euler(new Vector3(359.8f, 0f, 0f));
        SunRotationAxis = initSunRotation * Vector3.right;
        Sun = GetComponentInChildren<Light>();
        Sun.intensity = initDawnIntensity;

        if (DayLength == 0)
        {
            DayLength = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float SunSpeed;
        float normInitTime = initTime * DayLength / 24f;
        // This controls the Rotation of the Light Source,
        // Gives the appearance of rising and sitting
        dt = Time.time % DayLength + normInitTime;
        SunSpeed = 360f / DayLength;

        // This rotates our sun
        Sun.transform.rotation = Quaternion.AngleAxis(SunSpeed * (dt-normInitTime), SunRotationAxis);

        if (dt < DawnStart / 24f * DayLength)
        {
            // This if makes sure we don't do anything until 6am, sound like my life
            // Considered FSM, but this more of a cycle than a varying statemachine
            // Open for suggestions.
            Night(dt);
        }
        else if (dt < DayStart / 24f * DayLength)
        {
            Dawn(dt);
        }
        else if (dt < DuskStart / 24f * DayLength)
        {
            Day(dt);
        }
        else if (dt < NightStart / 24f * DayLength)
        {
            Dusk(dt);
        }
        else
        {
            Night(dt);
        }

    }

    // These handle aesthetics of Time Periods
    void Dawn(float time)
    {
        changeIntensity(time, DawnStart, DayStart, initDawnIntensity, initDayIntensity);
        //changeColorofSomethingToResemble(DawnColorsInWorldView);
        Debug.Log("Dawn");
    }
    void Day(float time)
    {
        changeIntensity(time, DayStart, DuskStart, initDayIntensity, initDuskIntensity);
        Debug.Log("Day");
    }
    void Dusk(float time)
    {
        changeIntensity(time, DuskStart, NightStart, initDuskIntensity, initNightIntensity);
        // Trying out the mark-down stuff
        Debug.Log("<b>Dusk</b>");
    }
    void Night(float time)
    {
        changeIntensity(time, NightStart, DawnStart, initNightIntensity, initDawnIntensity);
        Debug.Log("<i>Night</i>");
    }

    void changeIntensity(float time, float initTime, float finalTime, float initIntensity, float finalIntensity)
    {
        float duration = finalTime - initTime;
        float perCentTime = (time - initTime) / duration;

        Sun.intensity = (finalIntensity - initIntensity) * perCentTime + initIntensity;
    }

}