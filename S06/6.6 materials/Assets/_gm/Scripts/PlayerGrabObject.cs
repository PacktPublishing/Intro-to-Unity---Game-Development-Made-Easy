using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabObject : MonoBehaviour
{
    public Rigidbody _draggedRigidbody = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            GrabItem();
        }

        if(Input.GetMouseButtonUp(0) && _draggedRigidbody != null){
            _draggedRigidbody.useGravity = true;
            _draggedRigidbody = null;
        }

        if(_draggedRigidbody != null){
            _draggedRigidbody.position = this.transform.position + transform.forward*1.5f;
        }
    }


    void GrabItem(){
        RaycastHit hit;
        bool didIntersect = Physics.Raycast(transform.position, transform.forward, out hit, 50.0f);
        if(didIntersect==false){ return;}
        //the ray has intersected some collider!
        bool isCrate = hit.transform.gameObject.tag == "Crate";
        if(isCrate){
            _draggedRigidbody = hit.transform.gameObject.GetComponent<Rigidbody>();
            _draggedRigidbody.useGravity = false;
        }
    }
}
