using UnityEngine;

public class Movement : MonoBehaviour{
    
    public float speed = 1f;
    public float jumpPower = 1f;
    public float maxY = 1f;
    public GameObject visual;
    private Rigidbody rigidBody;
    public Animator handAnimator;
    public Animator bodyAnimator;
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        movementLogic();
        jumpLogic();
    }

    private void movementLogic(){
        
        // movement
        Vector3 playerInputH = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        Vector3 playerInputV = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        Vector3 playerInput = playerInputH + playerInputV;
        Vector3 moveVector  = transform.TransformDirection(playerInput) * speed;
        rigidBody.velocity = new Vector3(moveVector.x, rigidBody.velocity.y, moveVector.z);

        if(playerInput != Vector3.zero){
            visual.transform.forward = playerInput;
        }
    }

    private void jumpLogic(){

        if (Input.GetKeyDown("space") && (transform.position.y < maxY) ){
            rigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            bodyAnimator.Play("jump");
        }
        if (rigidBody.velocity.y > (jumpPower)){
            rigidBody.velocity = new Vector3(
                rigidBody.velocity.x,
                jumpPower,
                rigidBody.velocity.z
            );
        }
    }

}