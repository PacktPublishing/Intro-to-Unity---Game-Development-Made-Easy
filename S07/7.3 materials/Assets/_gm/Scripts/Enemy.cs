using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform _transformToFollow;
    public NavMeshAgent _myNavAgent;
    public EnemySensor _myEnemySensor;
    public Animator _animator;
    public Transform _runawayTransform;

    public GameObject _healthPotion;

    public EnemyDialogue_SO _enemyDialogue_SO;

    private int _health = 3;

    private float _previousAttackTime = -999;


    bool _destroyingSelf = false;
    float _destroying_beginTime = -1;
    bool _isAlerted = false;

    public void SubtractHealth(int subtractAmount){
        _health -= subtractAmount;

        if(_health == 0){
            _destroyingSelf = true;
            _destroying_beginTime = Time.time;
            _animator.SetTrigger("isDie");
            //Don't destroy self here, let the animation to play and complete.
            //Destroying will happenin in Update, few seconds later.
            Vector3 pos = transform.position + new Vector3(0, 1, 0);
            GameObject.Instantiate( _healthPotion,  pos,  Quaternion.identity );
        }
    }

    public void AddHealth(int howMuch){
        _health += howMuch;
    }

    public void Alert(){
        _isAlerted = true;
    }

    // Update is called once per frame
    void Update(){
        Run_to_Player();
        Attack_player_mayber();
        DestroySelf_maybe();
    }

    void Run_to_Player(){
        bool canRunAway = _health<=1 
                            && _destroyingSelf==false 
                            && _runawayTransform;

        bool canRunToPlayer = _myEnemySensor._isPlayerNearby  &&  
                             _destroyingSelf==false  &&
                             canRunAway==false;

        if (canRunToPlayer || _isAlerted){
            _myNavAgent.SetDestination(_transformToFollow.position);
        }
        else if (canRunAway){
            _myNavAgent.SetDestination(_runawayTransform.position);
        }
        else{
            _myNavAgent.ResetPath();
        }

        if (_myNavAgent.hasPath){
            _animator.SetBool("isRunning", true);
        }else{
            _animator.SetBool("isRunning", false);
        }

        if (canRunAway){
            NotifyOtherEnemies();
        }
    }

    void Attack_player_mayber(){
        bool can_attack_player = _myEnemySensor._isPlayerNearby && 
                                 _myEnemySensor._nearbyPlayer!=null &&
                                 _destroyingSelf==false;
        if (can_attack_player){
            if(Time.time > _previousAttackTime + 5) { 
                _myEnemySensor._nearbyPlayer.SubtractHealth(1);
                _previousAttackTime = Time.time;
                int attackNumber = Random.Range(1, 3);//1 or 2
                _animator.SetInteger("attackNumber", attackNumber);
            }else{
                _animator.SetInteger("attackNumber", 0);
            }
        }else{
            _animator.SetInteger("attackNumber", 0);
        }
    }


    void NotifyOtherEnemies(){
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5, new Vector3(1,1,1));
        for(int i=0; i<hits.Length; i++){
            bool isEnemy = hits[i].transform.gameObject.tag == "Enemy";
            if (isEnemy == false){ continue; }
            //else, it is enemy, proceed with this particular iteration:
            Enemy someEnemy = hits[i].transform.gameObject.GetComponentInParent<Enemy>();
            if (someEnemy == null || someEnemy == this){ continue; }
            //else someEnemy is NOT null AND it's not this particular "incarnation" of the script:
            someEnemy.Alert();
        }
    }


    void DestroySelf_maybe(){
        if (_destroyingSelf){
            float elapsed = Time.time - _destroying_beginTime;
            if(elapsed > 4){
                Destroy(this.gameObject);
            }
        }
    }
}
