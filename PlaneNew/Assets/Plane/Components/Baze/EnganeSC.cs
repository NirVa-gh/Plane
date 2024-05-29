using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnganeSC : MonoBehaviour
{
    public float MaxPower;

    public PlaneMS PlaneMSR;

    public Rigidbody PlaneRigidbodyR;

    void Update()
    {
        MaxPower = PlaneMSR.EnganesThrottleMax;

        PlaneRigidbodyR.AddForceAtPosition(gameObject.transform.forward * (MaxPower * PlaneMSR.EnganesThrottlePercent), gameObject.transform.position,ForceMode.Acceleration);

        //print(MaxPower * PlaneMSR.EnganesThrottlePercent);
    }
}
