using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLadder : MonoBehaviour
{
    public GameObject firstLadder;
    public GameObject secondLadder;
    public GameObject xMark;
    public GameObject player;
    public Rigidbody playerRigid;

    public bool haveLadder = false;
    private Vector3 upVector = new Vector3(0, 3, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickFirstLadder()
    {
        haveLadder = true;
        firstLadder.SetActive(false);
    }

    public void ClickMark()
    {
        Debug.Log(haveLadder);
        if (haveLadder)
        {
            secondLadder.SetActive(true);
        }
    }

    public void ClickSecondLadder()
    {
        Debug.Log(Vector3.Distance(player.transform.position, secondLadder.transform.position));
        if (Vector3.Distance(player.transform.position, secondLadder.transform.position) < 3.2)
        {
            if (player.transform.position.y < 10)
            {
                player.transform.position += upVector;
                playerRigid.useGravity = false;
            }
            else
            {
                player.transform.position -= upVector;
                playerRigid.useGravity = true;
            }
        }
    }
}
