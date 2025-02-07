using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform _myTransform;
    public Rigidbody _myRigidbody;
    public float _moveSpeed = 5;
    public float _jumpStrength = 50;

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        float delta = Time.deltaTime;
        Vector3 displacement_local = new Vector3(xMovement,0,zMovement)*_moveSpeed*delta;
        Vector3 displacement_world =  _myTransform.TransformDirection(displacement_local);
        _myRigidbody.position += displacement_world;

        bool isPressedSpace = Input.GetKeyDown(KeyCode.Space);
        if (isPressedSpace){
            Vector3 force = new Vector3(0,_jumpStrength,0);
            _myRigidbody.AddForce(force);
        }
    }
}
