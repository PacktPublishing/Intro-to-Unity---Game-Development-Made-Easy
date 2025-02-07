using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MGR : MonoBehaviour
{
    public Image _actualHealth0_img;
    public Image _actualHealth1_img;
    public Image _actualHealth2_img;

    public TextMeshProUGUI _scoreTxt;


    public void ShowScore(int score){
        _scoreTxt.text = "Score: " + score.ToString();
    }


    public void ShowHealth(int health){
        bool showHealth0 = health > 0;
        bool showHealth1 = health > 1;
        bool showHealth2 = health > 2;
        _actualHealth0_img.gameObject.SetActive(showHealth0);
        _actualHealth1_img.gameObject.SetActive(showHealth1);
        _actualHealth2_img.gameObject.SetActive(showHealth2);
    }


    void Update(){
        bool isShiftHeld = Input.GetKey(KeyCode.LeftShift);

        bool is1_pressed = Input.GetKeyDown(KeyCode.Alpha1);
        bool is2_pressed = Input.GetKeyDown(KeyCode.Alpha2);
        bool is3_pressed = Input.GetKeyDown(KeyCode.Alpha3);

        if(isShiftHeld && is1_pressed){  ShowScore(1); return; }
        if(isShiftHeld && is2_pressed){  ShowScore(2); return; }
        if(isShiftHeld && is3_pressed){  ShowScore(2); return; }

        if (is1_pressed) { ShowHealth(1);  }
        if (is2_pressed) { ShowHealth(2);  }
        if (is3_pressed) { ShowHealth(3); }
    }
}
