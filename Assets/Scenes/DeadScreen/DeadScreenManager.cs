using UnityEngine;
using UnityEngine.SceneManagement;


class DeadScreenManager : MonoBehaviour{


    void Start(){
        Invoke(nameof(loadNextScene),5);
    }

    void loadNextScene(){
        SceneManager.LoadScene(1);
    }
}