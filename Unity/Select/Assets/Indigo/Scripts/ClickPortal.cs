using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPortal : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRigid;

    [SerializeField]
    private float speed = 0.040f;

    // public GameObject portal;
    public GameObject player;
    public GameObject boat;
    public GameObject moon;
    public GameObject paddle;
    public GameObject paddleMsg;

    public bool onClicked = false;
    public bool havePaddle = false;
    public float portalDistance;
    public float moonDistance;

    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = player.GetComponent<Rigidbody>();
    }
    public void OnClickItem()
    {
        portalDistance = Vector3.Distance(player.transform.position, boat.transform.position);
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);

        if (portalDistance < 7 && player.transform.position.z < 8 && havePaddle)
        {
            myRigid.useGravity = false;
            player.transform.position = boat.transform.position - new Vector3(0, 2, 0);
            player.transform.rotation = boat.transform.rotation;
            paddle.transform.position = boat.transform.position + new Vector3(0, 1, 0);
            paddle.transform.rotation = boat.transform.rotation;
            onClicked = true;
        }

        if (havePaddle == false)
        {
            paddleMsg.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
        if (onClicked && 12 < moonDistance)
        {
            transform.position = transform.position + speed * transform.forward * Time.deltaTime;
            paddle.transform.position = paddle.transform.position + speed * transform.forward * Time.deltaTime;
            player.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
            
        // Z가 14까지

        if (moonDistance <= 12)
        {
            onClicked = false;
            player.transform.position = boat.transform.position - new Vector3(0, 1, 0);
        }
        // myRigid.MovePosition(transform.position + speed * transform.forward);
    }

    public void GetPaddle()
    {
        havePaddle = true;
    }

}
