using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGem : MonoBehaviour
{
    public GameObject player;
    public GameObject jem;

    public Vector3 offset = new Vector3(0, 5, 0);

    public float jemDistance;
    public float rotationSpeed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jem.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    public void Moving()
    {
        jemDistance = Vector3.Distance(player.transform.position, jem.transform.position);
        if (jemDistance < 200)
        {
            player.transform.position = jem.transform.position + offset;
        }
    }
}
