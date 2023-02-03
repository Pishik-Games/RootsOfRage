using UnityEngine;

public class EnemyScript : MonoBehaviour{

    public int health = 1;

    public void getPunch(){
        health--;
        if (health == 0){
            // var enemyHitVFX = GetComponentInChildren<ParticleSystem>();
            // Debug.Log(enemyHitVFX);
            // if (enemyHitVFX != null)
            // {
            //     enemyHitVFX.Play();
            // }
            Destroy(gameObject);
        }
    }    

}