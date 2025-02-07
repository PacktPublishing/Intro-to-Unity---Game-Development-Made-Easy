using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public bool _isPlayerNearby = false;
    public Player _nearbyPlayer;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            _isPlayerNearby = true;
            _nearbyPlayer = other.gameObject.GetComponentInParent<Player>();
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            _isPlayerNearby = false;
            _nearbyPlayer = null;
        }
    }
}
