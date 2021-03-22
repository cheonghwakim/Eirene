using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPortal : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRigid;

    [SerializeField]
    private float speed = 0.020f;

    // public GameObject portal;
    public GameObject player;
    public GameObject boat;
    public GameObject moon;

    public bool onClicked = false;
    public float portalDistance;
    public float moonDistance;

    private Vector3 offset = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // myRigid = GetComponent<Rigidbody>();
    }
    public void OnClickItem()
    {
        portalDistance = Vector3.Distance(player.transform.position, boat.transform.position);
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
        Debug.Log(portalDistance);
        Debug.Log(moonDistance);
        if (portalDistance < 7)
        {
            player.transform.position = boat.transform.position;
            player.transform.rotation = boat.transform.rotation;
            onClicked = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
        if (onClicked && 12 < moonDistance)
            transform.position = transform.position + speed * transform.forward * Time.deltaTime;
        // Z가 14까지
        if (onClicked)
        {
            player.transform.position = boat.transform.position;
        }
        if (moonDistance <= 12)
        {
            onClicked = false;
            player.transform.position = boat.transform.position;
        }
        // myRigid.MovePosition(transform.position + speed * transform.forward);
    }

}
