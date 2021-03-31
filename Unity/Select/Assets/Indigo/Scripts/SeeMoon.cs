using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeMoon : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    public GameObject boat;
    public GameObject moon;
    public Vector3 initialMoonPosition;

    public bool firstView = false;
    public bool onSeen = false;
    public float moonDistance;
    public Vector3 upDistance = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        initialMoonPosition = moon.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
        if (firstView)
        {
            if (onSeen)
            {
                if (moon.transform.position.y < 20)
                {
                    moon.transform.position = moon.transform.position + speed * upDistance * Time.deltaTime;
                }
            }
            else
            {
                if (initialMoonPosition.y < moon.transform.position.y && moon.transform.position.y < 19)
                {
                    moon.transform.position = moon.transform.position - speed * upDistance * Time.deltaTime;
                }
            }
        }
        
    }
    public void SeeItem()
    {
        Debug.Log("처음 봤어");
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
        if (moonDistance < 12 || firstView)
        {
            firstView = true;
            onSeen = true;
            if (moon.transform.position.y < 20)
            {
                moon.transform.position = moon.transform.position + speed * upDistance * Time.deltaTime;
            }
        }
    }
    public void SeeOffItem()
    {
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
        if (onSeen)
        {
            onSeen = false;
            if (initialMoonPosition.y < moon.transform.position.y)
            {
                moon.transform.position = moon.transform.position - speed * upDistance * Time.deltaTime;
            }
        }
    }
}
