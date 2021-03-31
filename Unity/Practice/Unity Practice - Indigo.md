# Unity Practice - Indigo



1. C# Script 

   ```c#
   // MyView.cs
   // 시선이 캐릭터 눈 높이에 고정되게 했다.
   // 캐릭터가 시야를 가려 캐릭터 쉐이더는 삭제했다.
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class MyView : MonoBehaviour
   {
       public GameObject player;
       private Vector3 offset = new Vector3(0, 2, 0);
       // Start is called before the first frame update
       void Start()
       {
           
       }
   
       // Update is called once per frame
       void Update()
       {
           transform.position = player.transform.position + offset + player.transform.forward;
       }
   }
   ```

   ```c#
   // PlayerMove.cs
   // 카메라의 위치는 캐릭터의 위치를 상속받고, 마우스(최종적으로는 VR 헤드트래킹) 좌우 움직임으로 회전, 위아래 움직임은 시선의 상하 움직임을 만든다.
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class PlayerMove : MonoBehaviour
   {
       [SerializeField]
       private float walkSpeed = 5.0f;
   
       [SerializeField]
       private float lookSensitivity;
   
       [SerializeField]
       private float cameraRotationLimit;
       private float currentCameraRotationX;
   
       [SerializeField]
       private Camera theCamera;
       private Rigidbody myRigid;
   
       private float horizontalInput;
       private float forwardInput;
       private bool isJumping;
       // Start is called before the first frame update
       void Start()
       {
           myRigid = GetComponent<Rigidbody>();
       }
   
       // Update is called once per frame
       void Update()
       {
           Move();
           CameraRotation();
           CharacterRotation();
       }
   
       private void Move()
       {
           float _moveDirX = Input.GetAxisRaw("Horizontal");
           float _moveDirZ = Input.GetAxisRaw("Vertical");
           Vector3 _moveHorizontal = transform.right * _moveDirX;
           Vector3 _moveVertical = transform.forward * _moveDirZ;
   
           Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;
   
           myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
       }
   
       private void CameraRotation()
       {
           float _xRotation = Input.GetAxisRaw("Mouse Y");
           float _cameraRotationX = _xRotation * lookSensitivity;
   
           currentCameraRotationX -= _cameraRotationX;
           currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
   
           theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
       }
   
       private void CharacterRotation()
       {
           float _yRotation = Input.GetAxisRaw("Mouse X");
           Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
           myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
       }
   }
   ```

   ```c#
   // ClickItem.cs
   // 노를 집게 만들었으나, 노의 mass에 의해 캐릭터 미끄러짐이 발생. -> mass 0으로 설정해 해결
   // But, rigid body이므로 다른 강체를 쳐서 움직임
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class ClickItem : MonoBehaviour
   {
       // Start is called before the first frame update
       public GameObject targetItem;
       public GameObject player;
       private Vector3 offset = new Vector3(0, 3, 0);
       public bool onClicked = false;
       public void OnClickItem(bool isClickAt)
       {
           Debug.Log(isClickAt);
           onClicked = true;
       }
   
       void Start()
       {
           
       }
   
       // Update is called once per frame
       void Update()
       {
           if (onClicked)
               targetItem.transform.position = player.transform.position + player.transform.forward;
           if (onClicked)
               targetItem.transform.rotation = player.transform.rotation;
       }
   }
   ```

   ```c#
   // ClickPortal.cs
   // 배를 클릭 시 배가 앞으로 움직이고, 캐릭터가 탑승한듯한 효과를 주었다.
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class ClickPortal : MonoBehaviour
   {
       [SerializeField]
       private Rigidbody myRigid;
   
       [SerializeField]
       private float speed = 0.010f;
   
       // public GameObject portal;
       public GameObject player;
       public GameObject boat;
   
       public bool onClicked = false;
   
       private Vector3 offset = new Vector3(0, 0, 0);
   
       // Start is called before the first frame update
       void Start()
       {
           // myRigid = GetComponent<Rigidbody>();
       }
       public void OnClickItem()
       {
           player.transform.position = boat.transform.position + offset;
           player.transform.rotation = boat.transform.rotation;
           onClicked = true;
       }
   
       // Update is called once per frame
       void Update()
       {
           if (onClicked)
               transform.position = transform.position + speed * transform.forward * Time.deltaTime;
           if (onClicked)
               player.transform.position = boat.transform.position + offset;
           // myRigid.MovePosition(transform.position + speed * transform.forward);
       }
   
   }
   ```
   
   ```c#
   // SeeMoon.cs
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class SeeMoon : MonoBehaviour
   {
       [SerializeField]
       private float speed = 0.010f;
   
       public GameObject boat;
       public GameObject moon;
       public Vector3 initialMoonPosition;
   
       public bool onSeen = false;
       public float moonDistance;
   
       // Start is called before the first frame update
       void Start()
       {
           initialMoonPosition = moon.transform.position;
       }
   
       // Update is called once per frame
       void Update()
       {
           
       }
       public void SeeItem()
       {
           moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
           if (moonDistance < 4 || onSeen)
           {
               onSeen = true;
               if (moon.transform.position.y < 10)
               {
                   moon.transform.position = moon.transform.position + speed * transform.up * Time.deltaTime;
               }
           }
       }
       public void SeeOffItem()
       {
           moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
           if (onSeen)
           {
               if (initialMoonPosition.y < moon.transform.position.y)
               {
                   moon.transform.position = moon.transform.position - speed * transform.up * Time.deltaTime;
               }
           }
       }
   }
   ```
   
   ```c#
   // ClickMoon
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class ClickMoon : MonoBehaviour
   {
       [SerializeField]
       private float speed = 0.050f;
   
       public GameObject boat;
       public GameObject moon;
       public float moonDistance;
       public bool onClicked = false;
       // Start is called before the first frame update
       void Start()
       {
           
       }
   
       // Update is called once per frame
       void Update()
       {
           moonDistance = Vector3.Distance(moon.transform.position, boat.transform.position);
           if (onClicked && moon.transform.position.y < 100)
           {
               moon.transform.position = moon.transform.position + moon.transform.up * speed;
           }
       }
       public void OnClickItem()
       {
           if (moonDistance < 10)
           {
               onClicked = true;
           }
   
       }
   }
   ```
   
   

