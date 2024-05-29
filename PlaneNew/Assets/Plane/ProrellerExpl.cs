using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProrellerExpl : MonoBehaviour
{
    public Transform explosionPrefab;
    public PlaneMS planeMS;
    public Transform plane;
    public GameObject body;

    void Start()
    {

    }

    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        print(planeMS.Speed);
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, position, rotation);
        body.SetActive(false);
    }
 
}
