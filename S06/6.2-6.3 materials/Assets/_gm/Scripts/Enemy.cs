using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform _transformToFollow;
    public NavMeshAgent _myNavAgent;
    public EnemySensor _myEnemySensor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_myEnemySensor._isPlayerNearby){
            _myNavAgent.SetDestination(_transformToFollow.position);
        }else{
            _myNavAgent.ResetPath();
        }
    }
}
