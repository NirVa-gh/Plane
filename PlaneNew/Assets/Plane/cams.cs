using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cams : MonoBehaviour
{
    public int index = 0;
    public Camera []cameras;
    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            Debug.Log(" button has been pressed");
            if (index < cameras.Length)
            {
                cameras[index - 1].gameObject.SetActive(false);
                cameras [index].gameObject.SetActive(true);
                Debug.Log("Camera with name: " + cameras[index].GetComponent<Camera>().name + ", is now enabled");
            }
            else
            {
                cameras[index - 1].gameObject.SetActive(false);
                index = 0;
                cameras[index].gameObject.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index--;
            Debug.Log(" button has been pressed");
            if (index < cameras.Length && index >= 0)
            {
                cameras[index + 1].gameObject.SetActive(false);
                cameras[index].gameObject.SetActive(true);
                Debug.Log("Camera with name: " + cameras[index].GetComponent<Camera>().name + ", is now enabled");
            }
            else
            {
                cameras[index + 1].gameObject.SetActive(false);
                index = 4;
                cameras[index].gameObject.SetActive(true);
            }
        }

    }
}
