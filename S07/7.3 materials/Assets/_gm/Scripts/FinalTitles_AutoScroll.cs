using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTitles_AutoScroll : MonoBehaviour
{
    public ScrollRect _myScrollRect;

    void Update(){
        _myScrollRect.verticalNormalizedPosition -= Time.deltaTime*0.1f; 
    }
}
