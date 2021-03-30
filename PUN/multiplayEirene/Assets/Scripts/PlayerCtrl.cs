// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Photon.Pun;

// public class PlayerCtrl : MonoBehaviourPun
// {
//     [SerializeField]
//     private float walkSpeed;

//     [SerializeField]
//     private float lookSensitivity; // 카메라 민감도

//     [SerializeField]
//     private float cameraRotationLimit;
//     private float currentCameraRotationX = 0;

//     [SerializeField]
//     private Camera theCamera;

//     private Rigidbody myRigid;

//     void Start() 
//     {
//         theCamera = FindObjectOfType<Camera>();
//         // Debug.Log("theCamera : " + theCamera);
//         myRigid = GetComponent<Rigidbody>();    
//     }

//     void update() 
//     {
//         Move();
//         CameraRotation();
//     }

//     private void Move()
//     {
//         Debug.Log("move!!!");
//         float _moveDirX = Input.GetAxisRaw("Horizontal");
//         float _moveDirZ = Input.GetAxisRaw("Vertical");

//         Vector3 _moveHorizontal = transform.right * _moveDirX;
//         Vector3 _moveVertical = transform.forward * _moveDirZ;

//         Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

//         myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

//     }

//     private void CameraRotation()
//     {
//         float _xRotation = Input.GetAxisRaw("Mouse Y");
//         float _cameraRotationX = _xRotation * lookSensitivity;
//         currentCameraRotationX -= _cameraRotationX;

//         // 범위 안으로 
//         currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        
//         theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
//     }
// }

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
