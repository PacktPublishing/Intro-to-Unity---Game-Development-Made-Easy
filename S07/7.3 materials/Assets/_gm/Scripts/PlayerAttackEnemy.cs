using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEnemy : MonoBehaviour
{
     // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            AttackEnemy();
        }
    }

     void AttackEnemy(){
        RaycastHit hit;
        bool didIntersect = Physics.Raycast(transform.position, transform.forward, out hit, 50.0f);
        if(didIntersect==false){ return;}
        //the ray has intersected some collider!
        bool isEnemy = hit.transform.gameObject.tag == "Enemy";
        if(isEnemy){
            Enemy foundEnemy = hit.transform.gameObject.GetComponentInParent<Enemy>();
            if (foundEnemy == null){
                return;
            }
            //found the enemy script!
            foundEnemy.SubtractHealth(1);
        }
    }
}
