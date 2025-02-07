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
    
    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update(){
        print(_myNumber);
        print(_listOfStrings[0]);
    }
}
