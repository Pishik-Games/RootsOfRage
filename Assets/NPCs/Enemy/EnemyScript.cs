using UnityEngine;

public class EnemyScript : MonoBehaviour{
    
    public int health = 4;
    public void getPunch(){
        if (health != 1){
            health--;
        } else {
            Destroy(gameObject);
        }
    }
}