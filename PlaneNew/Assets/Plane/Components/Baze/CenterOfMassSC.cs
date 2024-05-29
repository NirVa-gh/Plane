using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassSC : MonoBehaviour
{
    public Rigidbody rb;

    public void Activate (PlaneMS PlaneMSR)
    {
        PlaneMSR.PlaneRigidbody.centerOfMass = gameObject.transform.localPosition;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(rb.worldCenterOfMass, 0.1f);
    }*/
}
