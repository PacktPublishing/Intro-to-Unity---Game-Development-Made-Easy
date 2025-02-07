using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform _myTransform;
    public float _rotationSpeed = 0.01f;

    // Update is called once per frame
    void Update()
    {
        float x = _myTransform.localRotation.eulerAngles.x - Input.mousePositionDelta.y*_rotationSpeed;
        float y = _myTransform.localRotation.eulerAngles.y + Input.mousePositionDelta.x*_rotationSpeed;
        float z = 0;
        Quaternion extraRotation = Quaternion.Euler(x,y,z); 
        _myTransform.localRotation = extraRotation;
    }
}
