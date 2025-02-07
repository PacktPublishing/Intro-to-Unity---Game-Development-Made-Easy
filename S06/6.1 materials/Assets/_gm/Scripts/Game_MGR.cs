using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_MGR : MonoBehaviour
{
    
    void ReloadCurrentScene(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)){
            ReloadCurrentScene();
        }
    }

    void Start(){
        //see if other Game_MGR already exists somewhere.
        //If so, destroy our game object, to avoid duplicates.
        Game_MGR[] foundComponents = Component.FindObjectsByType<Game_MGR>(FindObjectsSortMode.None);

        for(int i =0; i<foundComponents.Length; i+=1){
            Game_MGR someMgr = foundComponents[i];
            if(someMgr!=null && someMgr != this){ 
                Destroy(this.gameObject);
                return;
            }
        }
        //move ourselves out of the Dungeons scene, to survive the re-loading
        DontDestroyOnLoad(this.gameObject);
    }
}
