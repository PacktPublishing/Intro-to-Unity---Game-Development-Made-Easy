using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform _transformToFollow;
    public NavMeshAgent _myNavAgent;
    public EnemySensor _myEnemySensor;
    public Animator _animator;

    private int _health = 3;

    private float _previousAttackTime = -999;

    public void SubtractHealth(int subtractAmount){
        _health -= subtractAmount;

        if(_health == 0){
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_myEnemySensor._isPlayerNearby){
            _myNavAgent.SetDestination(_transformToFollow.position);
        }else{
            _myNavAgent.ResetPath();
        }

        if (_myNavAgent.hasPath){
            _animator.SetBool("isRunning", true);
        }else{
            _animator.SetBool("isRunning", false);
        }

        if (_myEnemySensor._isPlayerNearby && _myEnemySensor._nearbyPlayer!=null){
            if(Time.time > _previousAttackTime + 5) { 
                _myEnemySensor._nearbyPlayer.SubtractHealth(1);
                _previousAttackTime = Time.time;
            }
        }
    }
}
