using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithLadder : MonoBehaviour
{
    public GameObject ladder;
    public GameObject player;
    public Rigidbody playerRigid;

    public Vector3 underPosition = new Vector3(-0.22f, 0.111f, 0.1f);
    public Vector3 upperPosition = new Vector3(-1.0f, 7.61f, 0.1f);
    public Vector3 direction;

    private bool move = false;
    private string dir;
    private float moveSpeed = 0.50f;

    // Start is called before the first frame update
    void Start()
    {
        direction = underPosition - upperPosition;
        playerRigid = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (dir == "upper")
            {
                if (player.transform.position.y < 5.5f)
                {
                    player.transform.position = player.transform.position - direction * moveSpeed * Time.deltaTime;
                }
                else
                {
                    player.transform.position = new Vector3(-3.33f, 7.61f, 0.1f);
                    playerRigid.useGravity = true;
                    move = false;
                }
            }
            else
            {
                if (0.1f < player.transform.position.y)
                {
                    player.transform.position = player.transform.position + direction * moveSpeed * Time.deltaTime;
                }
                else
                {
                    player.transform.position = new Vector3(-0.22f, 0.111f, 0.1f);
                    playerRigid.useGravity = true;
                    move = false;
                }
            }
        }
    }

    public void ClickLadder()
    {
        if (-4 < player.transform.position.x && player.transform.position.x < 0 && 0 < player.transform.position.z && player.transform.position.z < 0.5)
        {
            if (player.transform.position.y < 3)
            {
                dir = "upper";
            }
            else
            {
                dir = "under";
                player.transform.position = upperPosition - new Vector3(0, 2, 0);
            }

            move = true;
            playerRigid.useGravity = false;
        }
    }
}
