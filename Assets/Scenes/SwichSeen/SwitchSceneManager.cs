using UnityEngine;
using UnityEngine.SceneManagement;


class SwitchSceneManager : MonoBehaviour{


    void Start(){
        Invoke(nameof(loadNextScene),3);
    }

    void loadNextScene(){
        SceneManager.LoadScene(2);
    }
}