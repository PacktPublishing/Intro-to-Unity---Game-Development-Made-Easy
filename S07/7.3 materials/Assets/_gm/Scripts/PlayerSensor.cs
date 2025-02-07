using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public Player _myPlayer;

    private void OnTriggerEnter(Collider other){
        bool isFeeling_a_potion = other.gameObject.tag == "Potion";
        if (isFeeling_a_potion){
            _myPlayer.AddHealth(1);
            Destroy(other.gameObject);
        }
    }
}
