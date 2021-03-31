# Unity Practice - Truck & Plane



1. Asset Import

   > 상단 메뉴 Assets -> Import Package -> Custom Package 로 Asset을 Import

2. Scene 등록

   > 하단 Project 창 -> Assets/Scenes/`유니티파일`을 더블 클릭해 Hierarchy에 등록

3. Object 배치

   > Assets에서 미리 등록해 가져온 Object를 골라 Hierarchy에 드래그 앤 드랍하여 맵에 배치한 뒤 마우스로 세부 배치한다.

4. Obstacle(Object) 복제

   > Ctrl + D 를 이용해 Object를 복제할 수 있다.

5. Transform

   > 모든 Object는 Transform 값을 가지고 있고, 이는 우측 Inspector 창에 표시된다.
   >
   > Transform은 Position, Rotation, Scale을 가지고 있다.

6. 강체(질량이 있는 물체)화 하기

   > Inspector 창 최하단 `Add Component` 버튼을 눌러 Rigidbody를 선택한다.
   >
   > Rigidbody는 속성값으로 Mass를 가지고 있으며 중력과 동역학을 적용시킬 수 있는 토클이 있다.

7. Object에 코드 적용하기

   > Object에 Input, 시간의 변화, 다른 Object와의 상호작용 등에 관하여 코드를 적용할 Script를 작성할 수 있다.
   >
   > Project 창 -> Assets폴더를 우클릭 하여 Scripts 폴더를 만든다.
   >
   > Scripts 폴더에 C# Script를 생성하고 코드를 적용한다.

8. Input 세팅

   > 상단 메뉴 Edit -> Project Settings -> Input 에서 각 Input 값에 따른 Output을 확인하거나 수정할 수 있다.
   >
   > Project Settings 에서는 중력이나 그래픽, 오디오 등 다른 많은 것을 확인 및 수정할 수 있다.

9. C# Script 예시

   ```c#
   // Truck / PlayerController.cs
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class PlayerController : MonoBehaviour
   {
       // 직진 및 회전 속도, Input의 Output을 정의한다.
       private float speed = 5.0f;
       private float turnSpeed = 25.0f;
       private float horizontalInput;
       private float forwardInput;
   
       // Start is called before the first frame update
       void Start()
       {
           
       }
   
       // Update is called once per frame
       void Update()
       {
           // Project Settings . Input 에서 "Horizontal"이라는 이름을 가진 Input값을 눌렀을 때의 Output
           horizontalInput = Input.GetAxis("Horizontal");
           forwardInput = Input.GetAxis("Vertical");
   
           // we'll move the vehicle forward
           // Time.deltaTime은 1프레임의 시간과 동일
           transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
           // Vector3.up은 y축과 같다.
           transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
       }
   }
   ```

   ```c#
   // Truck / FollowPlayer.cs
   // 카메라(사용자 시선)가 트럭을 따라다니게 만드는 Script
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class FollowPlayer : MonoBehaviour
   {	
       // GameObject를 선택할 것이고, 이름을 player로 정하겠다는 의미
       public GameObject player;
       private Vector3 offset = new Vector3(0, 5, -7);
   
       // Start is called before the first frame update
       void Start()
       {
           
       }
   
       // Update is called once per frame
       void Update()
       {
           // player라는 Object의 position + offset 값.
           transform.position = player.transform.position + offset;
           transform.rotation = player.transform.rotation;
       }
   }
   ```

   ```c#
   // Plane / PlayerControllerX.cs
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class PlayerControllerX : MonoBehaviour
   {
       public float speed;
       public float rotationSpeed;
       public float verticalInput;
   
       // Start is called before the first frame update
       void Start()
       {
   
       }
   
       // Update is called once per frame
       void FixedUpdate()
       {
           // get the user's vertical input
           verticalInput = Input.GetAxis("Vertical");
   
           // move the plane forward at a constant rate
           transform.Translate(Vector3.forward * speed);
   
           // tilt the plane up/down based on up/down arrow keys
           transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
       }
   }
   ```

   ```c#
   // Plane / FollowPlayerX.cs
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class FollowPlayerX : MonoBehaviour
   {
       public GameObject plane;
       private Vector3 offset = new Vector3(30, 0, 10);
   
       // Start is called before the first frame update
       void Start()
       {
   
       }
   
       // Update is called once per frame
       void Update()
       {
           transform.position = plane.transform.position + offset;
       }
   }
   ```

   ```c#
   // Plane / SpinPropeller.cs
   // Plane Object에 소속되어 있는 Propeller가 독립적으로 회전하도록 만드는 Script
   
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class SpinPropeller : MonoBehaviour
   {
       public float rotationSpeed;
    
       // Start is called before the first frame update
       void Start()
       {
           
       }
   
       // Update is called once per frame
       void Update()
       {
           transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
       }
   }
   ```

10. Script를 Object에 적용

    > Assets 경로 내 작성된 Script 파일을 Hierarchy 창 내 Object에 드래그 앤 드롭하면 오른쪽 Inspector에 Script가 등록된다.
    >
    > Inspector창에서는 Script내 public으로 정의된 변수를 확인할 수 있고, 변경하여 게임을 실행시킬 수 있다.