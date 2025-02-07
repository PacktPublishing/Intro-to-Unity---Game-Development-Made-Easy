using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float _myNumber;
    public int _myWholeNumber;
    public bool _myBoolean;
    public string _myLetters;
    public List<string> _listOfStrings;

    public GameObject _myToucher;


    public GameObject _leftDoor;
    public GameObject _rightDoor;


    private void OnCollisionEnter(Collision collision)
    {
        print("(OnCollisionEnter) Something touched me: " + collision.gameObject.name);
        _myToucher = collision.gameObject;

        if(collision.gameObject.tag == "Crate"){
            _leftDoor.SetActive(false);
            _rightDoor.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        print("(OnCollisionExit) Something stopped touching me: " + collision.gameObject.name);
        _myToucher = null;

        if(collision.gameObject.tag == "Crate"){
            _leftDoor.SetActive(true);
            _rightDoor.SetActive(true);
        }
    }


    void Update(){
        // print the name of myToucher, but only if it points to some GameObject.
        if (_myToucher != null){
            print("being touched by " + _myToucher.name);
        }
    }
}
