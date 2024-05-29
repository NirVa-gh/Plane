using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Данные : MonoBehaviour
{
    public TMP_Text Hight;
    public GameObject ground;
    public GameObject plane;
    public TMP_Text Speed;
    public float speedplane;
    public GameObject speedD;
    public GameObject hightD;
    public PlaneMS PlaneMSR;

    void Start()
    {
        speedD = GameObject.Find("Skorost");
        hightD = GameObject.Find("Visota");
    }
    void Update()
    {
        speedplane = PlaneMSR.Speed;
        Hight = hightD.GetComponent<TMP_Text>();
        Hight.text = ((int)(plane.transform.position.y - ground.transform.position.y)).ToString();
        Speed = speedD.GetComponent<TMP_Text>();

        // Mathf.Round
        Speed.text = (Mathf.Round(speedplane * 10)).ToString();

    }
}