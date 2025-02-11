using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light _myLight;
    public Transform _myTransform;

    public float _mySecretRandomNumber;


    void Start(){
        _mySecretRandomNumber = Random.Range(0.0f, 1.0f);
    }

}
