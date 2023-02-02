using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{

    public Animator handAnimator;
    public bool isActive;
    void FixedUpdate(){
        attackLogic();   
    }

    private void attackLogic(){

        if (Input.GetKeyDown("q") ){
            handAnimator.Play("punch");
            isActive = true;
            Invoke(nameof(deactive),0.2f);
        }
    }

    private void deactive(){
        isActive = false;
    }

    void OnTriggerEnter(Collider other){
        if(isActive){
            var enemy = other.gameObject.GetComponent<EnemyScript>();
            if(enemy!=null){
                enemy.getPunch();
            }
        }
    }

        
}
