using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSurfaceSC : MonoBehaviour
{
    //public ComponentCT ParentComponentCTR;

    public bool EnableAsPanel;
    public bool EnableAsWing;
    public bool EnableAsRudder;
    public bool EnableAsFlap;

    public bool WS;
    public bool AD;
    public bool QE;
    public bool FixedRuddForce;

    public float PanelSquare;
    public float WingAirdynamicCoffic;

    public float RuddForce;

    public PlaneMS PlaneMSR;

    public Rigidbody PlaneRigidbodyR;

    Vector3 ForceVector;
    Vector3 LocalSpeed;

    Vector3[] AxisVectors = new Vector3[3];

    public GameObject ToForward;
    public GameObject PanelTop;

    void Start()
    {
        LastPosition = gameObject.transform.position;
    }

    void Update()
    {
        GetLocalSpeed();
        //print(LocalSpeed);

        WingAirdynamicCoffic = PlaneMSR.WingsAirdynamicCoffic;

        if (FixedRuddForce == false)
        {
            RuddForce = PlaneMSR.RuddForce;
        }

        ForceVector = Vector3.zero;

        // Panel
        if (EnableAsPanel)
        {
            ForceVector += (PanelTop.transform.position - gameObject.transform.position) * (PanelSquare * -(LocalSpeed.y * Mathf.Abs(LocalSpeed.y)));
            //ForceVector += gameObject.transform.up * (PanelSquare * -(LocalSpeed.y));
        }

        // Wing
        if (EnableAsWing)
        {
            ForceVector += (PanelTop.transform.position - gameObject.transform.position) * (WingAirdynamicCoffic * Mathf.Abs(LocalSpeed.z));
        }

        // Rudd
        if (EnableAsRudder)
        {
            if (WS)
            {
                ForceVector += (PanelTop.transform.position - gameObject.transform.position) * (RuddForce * PlaneMSR.RuddWS * Mathf.Abs(LocalSpeed.z));
            }
            if (AD)
            {
                ForceVector += (PanelTop.transform.position - gameObject.transform.position) * (RuddForce * PlaneMSR.RuddAD * Mathf.Abs(LocalSpeed.z));
            }
            if (QE)
            {
                ForceVector += (PanelTop.transform.position - gameObject.transform.position) * (RuddForce * PlaneMSR.RuddQE * Mathf.Abs(LocalSpeed.z));
            }
        }

        //print(ForceVector);
        PlaneRigidbodyR.AddForceAtPosition(ForceVector, gameObject.transform.position, ForceMode.Force);
    }


    Vector3 LastPosition;
    Vector3 GlobalSpeed;
    float AbsSpeed;
    float VectorsAngle;
    void GetLocalSpeed()
    {
        GlobalSpeed = gameObject.transform.position - LastPosition;
        LastPosition = gameObject.transform.position;

        AbsSpeed = Mathf.Abs(GlobalSpeed.x) + Mathf.Abs(GlobalSpeed.y) + Mathf.Abs(GlobalSpeed.z);

        VectorsAngle = Mathf.Abs(Vector3.SignedAngle((ToForward.transform.position - gameObject.transform.position), GlobalSpeed, Vector3.one));
        VectorsAngle = ((VectorsAngle - 90) * -1) / 90; // transform to range from -1 to 1
        LocalSpeed.z = AbsSpeed * VectorsAngle;

        VectorsAngle = Mathf.Abs(Vector3.SignedAngle((PanelTop.transform.position - gameObject.transform.position), GlobalSpeed, Vector3.one));
        VectorsAngle = ((VectorsAngle - 90) * -1) / 90; // transform to range from -1 to 1
        LocalSpeed.y = AbsSpeed * VectorsAngle;
    }
}
