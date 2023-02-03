using UnityEngine;
using UnityEngine.SceneManagement;

class FightSceneManager: MonoBehaviour{

    public GameObject player;
    void Start(){
        GlobalGameManager.CanPlayerMove = true;   
    }

    void Update(){
        if(player.transform.position.y<-10){
            SceneManager.LoadScene(1);
        }
    }

}