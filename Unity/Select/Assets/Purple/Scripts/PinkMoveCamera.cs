using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkMoveCamera : MonoBehaviour
{
    [SerializeField]
    private float lookSensitivity = 3.0f;
    private float walkSpeed = 25.0f;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;
    private float currentCameraRotationY;

    [SerializeField]
    private Camera theCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        Move();
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _yRotation = Input.GetAxisRaw("Mouse X");
        float _cameraRotationX = _xRotation * lookSensitivity;
        float _cameraRotationY = _yRotation * lookSensitivity;

        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        currentCameraRotationY -= _cameraRotationY;

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, -currentCameraRotationY, 0f);
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;

        theCamera.transform.position += (_velocity * Time.deltaTime);
    }
}
