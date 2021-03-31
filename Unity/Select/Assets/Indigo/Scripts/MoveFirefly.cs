using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFirefly : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.50f;

    public GameObject boat;
    public GameObject moon;
    public GameObject boatFirefly;
    public Vector3 initialBoatPosition;
    public Vector3 moonHeading;
    public float moonDistance;

    public bool onClickedMoon = false;

    private Vector3 offset = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        initialBoatPosition = boat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (initialBoatPosition != boat.transform.position && !onClickedMoon)
        {
            boatFirefly.transform.position = boat.transform.position + offset;
        }
        if (onClickedMoon)
        {
            moonHeading = moon.transform.position - boatFirefly.transform.position;
            if (moon.transform.position != boatFirefly.transform.position)
            {
                boatFirefly.transform.position = boatFirefly.transform.position + moonHeading * speed * Time.deltaTime;
                moonDistance = Vector3.Distance(moon.transform.position, boatFirefly.transform.position);
                if (2 < moonDistance)
                {
                    boatFirefly.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
        }
    }
    public void OnClickItem()
    {
        if (19 < moon.transform.position.y)
        {
            onClickedMoon = true;
        }

    }
}
