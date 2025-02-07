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

    public GameObject _gameOverGO;


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

        if (Input.GetKey(KeyCode.LeftControl)){
            _gameOverGO.SetActive(true);
        }
    }

    void Start(){
        _gameOverGO.SetActive(false);

        //see if other Game_MGR already exists somewhere.
        //If so, destroy our game object, to avoid duplicates.
        UI_MGR[] foundComponents = Component.FindObjectsByType<UI_MGR>(FindObjectsSortMode.None);

        for(int i =0; i<foundComponents.Length; i+=1){
            UI_MGR someMgr = foundComponents[i];
            if(someMgr!=null && someMgr != this){ 
                Destroy(this.gameObject);
                return;
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
