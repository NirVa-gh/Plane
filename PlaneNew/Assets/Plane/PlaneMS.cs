using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMS : MonoBehaviour
{
    public float EnganesThrottlePercent;
    public float EnganesThrottleMax;

    public float WingsAirdynamicCoffic;

    public float RuddForce;

    public PlaneCT PlaneCTR;

    public Vector3 LocalSpeed;

    public List<GameObject> PlaneVectors = null;

    public Rigidbody PlaneRigidbody;

    public float Speed;

    private void Start()
    {
        PlaneRigidbody = GetComponent<Rigidbody>();

        int i = 0;
        while (i < PlaneCTR.Enganes.Count)
        {
            PlaneCTR.Enganes[i].PlaneRigidbodyR = PlaneRigidbody;
            i++;
        }

        i = 0;
        while (i < PlaneCTR.AirSurfaces.Count)
        {
            PlaneCTR.AirSurfaces[i].PlaneRigidbodyR = PlaneRigidbody;
            i++;
        }

        PlaneCTR.CenterOfMassSCR.Activate(this);
    }

    public float RuddWS;
    public float RuddAD;
    public float RuddQE;

    void Update()
    {
        

        Speed = Mathf.Abs(PlaneRigidbody.velocity.x) + Mathf.Abs(PlaneRigidbody.velocity.y) + Mathf.Abs(PlaneRigidbody.velocity.z);
        LocalSpeed = GetBodyLocalSpeedFromGlobal(gameObject.transform.position, PlaneVectors, PlaneRigidbody.velocity, Speed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            EnganesThrottlePercent = 100;
            gameObject.GetComponent<Animator>().SetBool("StartEngane", true);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            EnganesThrottlePercent = 0;
            gameObject.GetComponent<Animator>().SetBool("StartEngane", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            RuddWS = -1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RuddWS = 1;
        }
        else
        {
            RuddWS = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            RuddAD = 1;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RuddAD = -1;
        }
        else
        {
            RuddAD = 0;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            RuddQE = 1;
        }
        else if(Input.GetKey(KeyCode.E))
        {
            RuddQE = -1;
        }
        else
        {
            RuddQE = 0;
        }
    }

    Vector3 GetBodyLocalSpeedFromGlobal(Vector3 PlanePosition, List<GameObject> PlaneVectors, Vector3 GlobalSpeed, float PlaneAbsSpeed)
    {
        Vector3 LocalSpeed = new Vector3(0, 0, 0);

        int i = 0;
        while (i < 3)
        {
            float VectorsAngle = Mathf.Abs(Vector3.SignedAngle((PlaneVectors[i].transform.position - PlanePosition), GlobalSpeed, Vector3.one));

            VectorsAngle = ((VectorsAngle - 90) * -1) / 90; // transform to range from -1 to 1

            LocalSpeed[i] = PlaneAbsSpeed * VectorsAngle;

            i++;
        }

        //Debug.Log(LocalSpeed);
        return LocalSpeed;
    }
}
