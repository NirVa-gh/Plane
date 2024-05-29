using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Transform explosionPrefab;
    public PlaneMS planeMS;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (planeMS.Speed >= 50)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            Instantiate(explosionPrefab, position, rotation);
        }
    }
}
