using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCtrl : MonoBehaviourPun
{
    public float speed = 5.0f;
    public float rotSpeed = 120.0f;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

        if(photonView.IsMine)
        {
            // 자신의 플레이어에게만 카메라 제어권을 연결
            Debug.Log("target: " + tr);
            // Debug.Log(Camera.main);
            Camera.main.GetComponent<SmoothFollow>().target = tr;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!photonView.IsMine) // 현재 player가 local이 아니라면 
        {
            return;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        tr.Translate(Vector3.forward * v * Time.deltaTime * speed);
        tr.Rotate(Vector3.up * h * Time.deltaTime * rotSpeed);
    }
}
