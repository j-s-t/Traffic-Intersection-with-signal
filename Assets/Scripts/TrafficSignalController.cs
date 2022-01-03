using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignalController : MonoBehaviour
{
    public GameObject redSignalLightObject, yellowSignalLightObject, greenSignalLightObject, counterBoardObject;
    public Material blackMaterial, redMaterial, yellowMaterial, greenMaterial;
    public float redSignalResetPeriod = 40.0f;
    public float yellowSignalResetPeriod = 20.0f;
    public float greenSignalResetPeriod = 30.0f;
    public float activeTimer;
    public int integerRepOfactiveTimer;
    public string activeSignal;

    // Start is called before the first frame update
    void Start()
    {

        activeSignal = "red";
        activeTimer = redSignalResetPeriod;

        redSignalLightObject = GameObject.Find("RedSignalLight");
        yellowSignalLightObject = GameObject.Find("YellowSignalLight");
        greenSignalLightObject = GameObject.Find("GreenSignalLight");
        counterBoardObject = GameObject.Find("SignalTime");

        redMaterial = Resources.Load<Material>("Materials/Material-Red-Signal");
        yellowMaterial = Resources.Load<Material>("Materials/Material-Yellow-Signal");
        greenMaterial = Resources.Load<Material>("Materials/Material-Green-Signal");
        blackMaterial = Resources.Load<Material>("Materials/Material-Black-Signal");


        redSignalLightObject.GetComponent<Renderer>().material = redMaterial;
        yellowSignalLightObject.GetComponent<Renderer>().material = blackMaterial;
        greenSignalLightObject.GetComponent<Renderer>().material = blackMaterial;

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        activeTimer -= Time.fixedDeltaTime;
        integerRepOfactiveTimer = (int)activeTimer;
        if (activeTimer <= 0)
        {
            resetTimerAndSwitchLights();
        }

        counterBoardObject.GetComponent<TextMesh>().text = integerRepOfactiveTimer.ToString();
        //print((int)targetTime);
    }

    public void resetTimerAndSwitchLights()
    {

        switch (activeSignal)
        {
            case "red":
                redSignalLightObject.GetComponent<Renderer>().material = blackMaterial;
                yellowSignalLightObject.GetComponent<Renderer>().material = yellowMaterial;
                activeSignal = "yellow";
                activeTimer = yellowSignalResetPeriod;

                break;
            case "yellow":
                yellowSignalLightObject.GetComponent<Renderer>().material = blackMaterial;
                greenSignalLightObject.GetComponent<Renderer>().material = greenMaterial;
                activeSignal = "green";
                activeTimer = greenSignalResetPeriod;

                break;
            case "green":
                greenSignalLightObject.GetComponent<Renderer>().material = blackMaterial;
                redSignalLightObject.GetComponent<Renderer>().material = redMaterial;
                activeSignal = "red";
                activeTimer = redSignalResetPeriod;

                break;
            default:
                redSignalLightObject.GetComponent<Renderer>().material = redMaterial;
                activeSignal = "red";
                activeTimer = redSignalResetPeriod;
                break;

        }

    }
}
