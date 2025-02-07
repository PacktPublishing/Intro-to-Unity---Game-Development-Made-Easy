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
        _myRigidbody.position += new Vector3(xMovement,0,zMovement)*_moveSpeed*delta;

        bool isPressedSpace = Input.GetKeyDown(KeyCode.Space);
        if (isPressedSpace){
            Vector3 force = new Vector3(0,_jumpStrength,0);
            _myRigidbody.AddForce(force);
        }
    }
}
