using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour
{
    public float move;
    public Camera[] cams;
    public int count;
    public int length;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            count++;
            if (count >= length - 1)
            {
                count = 0;
            }
            length = cams.Length;
            if (count != 0)
            {
                cams[count].enabled = true;
                cams[count - 1].enabled = false;
            }

            if (count == 0)
            {
                cams[count].enabled = true;
                cams[length - 1].enabled = false;
            }

        }

    }
}
