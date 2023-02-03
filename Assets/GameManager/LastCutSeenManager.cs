using UnityEngine.SceneManagement;
using UnityEngine;


class LastCutSeenManager: MonoBehaviour{
    public AudioSource audioSource;
    public AudioClip yeaaa;
    public AudioClip fosh;

    void Start(){
        Invoke(nameof(playYea), 1);
        Invoke(nameof(playFosh), 6.5f);
        Invoke(nameof(quit), 8);
    }

    void playFosh(){
        audioSource.PlayOneShot(fosh);
    }
    void playYea(){
        audioSource.PlayOneShot(yeaaa);
    }
    void quit(){
        Application.Quit();
    }
}