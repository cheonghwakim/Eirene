using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLocate : MonoBehaviour
{
    public Camera theCamera;
    public GameObject textColor;
    public float textAngle;
    // Start is called before the first frame update
    void Start()
    {
        textColor.transform.position = theCamera.transform.position + new Vector3(0, 0, 300);
        textColor.transform.Rotate(0, 270, 0);
        textColor.transform.RotateAround(theCamera.transform.position, theCamera.transform.up, textAngle+180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
