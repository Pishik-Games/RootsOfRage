using UnityEngine;

public class EnemyScript : MonoBehaviour{
    
    public int health = 4;
    public void getPunch(){
        if (health != 1){
            Debug.Log($"akh {health}");
            health--;
        } else {
            Debug.Log("man moldam");
            Destroy(gameObject);
        }
    }
}