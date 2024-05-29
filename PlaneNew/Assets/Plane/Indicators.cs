using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicators : MonoBehaviour
{

    public Image HealthBar, OilBar, SpeedBar;

    public float healthAmount = 100;
    public float gasAmount = 100;
    public float speedAmount = 100;
    public float uiSpeedAmount = 100;
    private float changeFactor = 1;

    public PlaneMS planeMS;

    private float speedPlane;


    public float secondToEmptyGas;


    // diff speed
    void Start()
    {
        HealthBar.fillAmount = healthAmount / 100;

        speedPlane = planeMS.Speed;
    }

    void Update()
    {
        if (planeMS.EnganesThrottlePercent > 0)
        {

            if (gasAmount > 0)
            {
                gasAmount -= 100 / secondToEmptyGas * Time.deltaTime;
                OilBar.fillAmount = gasAmount / 100;
            }
            if (gasAmount < 1)
            {
                planeMS.EnganesThrottleMax = 0;
                speedPlane = 0;
            }
        }
        if (speedPlane >= 0)
        {

            uiSpeedAmount = Mathf.Lerp(uiSpeedAmount, planeMS.Speed, Time.deltaTime * changeFactor);
            SpeedBar.fillAmount = uiSpeedAmount / 150;
        }


    }
}