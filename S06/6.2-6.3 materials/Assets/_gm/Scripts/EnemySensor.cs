using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public bool _isPlayerNearby = false;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            _isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            _isPlayerNearby = false;
        }
    }
}
