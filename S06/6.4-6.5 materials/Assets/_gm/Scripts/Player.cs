using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UI_MGR _ui_mgr;
    public Game_MGR _game_mgr;

    private int _health = 3;

    public void SubtractHealth(int subtractAmount){
        _health -= subtractAmount;

        if(_health == 0){
            _ui_mgr.ShowGameOverScreen(true);
            _game_mgr.ReloadCurrentScene();
        }
    }

    public void Update(){
        _ui_mgr.ShowHealth(_health);
    }
}
