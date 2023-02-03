using UnityEngine;
using UnityEngine.SceneManagement;


class FirstSceneManager: MonoBehaviour{

    public AudioSource audioSource;
    public AudioClip fosh;
    public AudioClip cry;

    void Start(){
        Invoke(nameof(playFosh), 6);
        Invoke(nameof(playFosh), 8);
        Invoke(nameof(loadNextScene), 14);
        playCry();
    }

    void loadNextScene(){
        SceneManager.LoadScene(1);
    }

    void playCry(){
        audioSource.PlayOneShot(cry);
    }

    void playFosh(){
        audioSource.PlayOneShot(fosh);
    }
}