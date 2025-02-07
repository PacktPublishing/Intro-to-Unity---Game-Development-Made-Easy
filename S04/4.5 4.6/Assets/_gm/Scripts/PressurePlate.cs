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

    private void OnCollisionEnter(Collision collision)
    {
        print("(OnCollisionEnter) Something touched me: " + collision.gameObject.name);
        _myToucher = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        print("(OnCollisionExit) Something stopped touching me: " + collision.gameObject.name);
        _myToucher = null;
    }


    void Update(){
        // print the name of myToucher, but only if it points to some GameObject.
        if (_myToucher != null){
            print("being touched by " + _myToucher.name);
        }
    }
}
