using UnityEngine;
using UnityEngine.SceneManagement;


class FirstSceneManager: MonoBehaviour{

    void Start(){
        Invoke(nameof(loadNextScene),14);
    }

    void loadNextScene(){
        SceneManager.LoadScene(1);
    }
}