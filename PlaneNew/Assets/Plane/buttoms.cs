using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttoms : MonoBehaviour
{
    public GameObject propeller;
    public cams cams99;

    void Start()
    {

    }
    public void StartButtom()
    {
        Debug.Log("check");
        //propeller.GetComponent<Animator>().SetTrigger("Start");
    }
    public void GoButtom()
    {

    }
    public void cams()
    {
        Debug.Log("CHECK");
        cams99.index++;
    }
}
