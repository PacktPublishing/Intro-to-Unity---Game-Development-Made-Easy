using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform _myCameraTransform;
    public Transform _myPlayerTransform;
    public float _rotationSpeed = 0.01f;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = _myCameraTransform.localRotation.eulerAngles.x - Input.mousePositionDelta.y*_rotationSpeed;
        float y = 0;
        float z = 0;
        Quaternion extraRotation = Quaternion.Euler(x,y,z);
        _myCameraTransform.localRotation = extraRotation;

        x = 0;
        y = _myPlayerTransform.localRotation.eulerAngles.y + Input.mousePositionDelta.x * _rotationSpeed;
        z = 0;
        Quaternion playerExtraRotation = Quaternion.Euler(x,y,z);
        _myPlayerTransform.localRotation = playerExtraRotation;

    }
}
