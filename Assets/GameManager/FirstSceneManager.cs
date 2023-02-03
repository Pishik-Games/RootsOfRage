using UnityEngine;
using UnityEngine.SceneManagement;


class FirstSceneManager: MonoBehaviour{

    void Start(){
        Invoke(nameof(loadNextScene),3);       
    }


    void loadNextScene(){
        SceneManager.LoadScene(1);
    }
    void Update(){
        
    }
}