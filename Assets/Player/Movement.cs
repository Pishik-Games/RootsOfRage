using UnityEngine;

public class Movement : MonoBehaviour{
    
    public float speed = 1f;
    // public GameObject head;
    private Rigidbody rigidBody;

    // public Animator charecterAnimator;
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        // runningAnimationLogic();
        movementLogic();
    }

    private void movementLogic(){
        
        // movement
        Vector3 playerInputH = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        Vector3 playerInputV = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        Vector3 playerInput = playerInputH + playerInputV;
        Vector3 moveVector  = transform.TransformDirection(playerInput) * speed;
        rigidBody.velocity = new Vector3(moveVector.x, rigidBody.velocity.y, moveVector.z);

        // if(playerInput != Vector3.zero){
        //     head.transform.forward = playerInput;
        // }
    }

    // private void runningAnimationLogic(){
    //     var len = Vector3.Distance(Vector3.zero, rigidBody.velocity);
    //     if(len > 1) len = 1;
    //     charecterAnimator.SetFloat("Speed",len);
    // }

}