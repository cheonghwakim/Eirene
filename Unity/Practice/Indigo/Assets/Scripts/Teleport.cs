using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject jam;
    public float jamDistance;
    public float rotationSpeed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    public void MoveToJam()
    {
        jamDistance = Vector3.Distance(player.transform.position, jam.transform.position);
        if (jamDistance < 20)
        {
            player.transform.position = jam.transform.position;
        }
        else
        {
            Debug.Log("너무 멀어요");
        }
    }
}
