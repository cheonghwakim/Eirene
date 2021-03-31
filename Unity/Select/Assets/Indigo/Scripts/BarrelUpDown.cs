using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelUpDown : MonoBehaviour
{
    public GameObject barrel;
    public Vector3 initialBarrelPosition;
    public bool dir = true;
    public float updownSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        initialBarrelPosition = barrel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dir && barrel.transform.position.y < initialBarrelPosition.y + 1)
        {
            
        }
    }
}
