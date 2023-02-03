using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour{
    
    public float speed = 1f;
    public float jumpPower = 1f;
    public float maxY = 1f;
    public GameObject pauseUI;
    public bool collidedWithEnemy;
    public GameObject visual;
    private Rigidbody rigidBody;
    public Animator handAnimator;
    public Animator bodyAnimator;

    public GameObject rageBar;
    public GameObject collisionWithEnemy;



    private bool isOnPause ;
    void Start(){
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        if(GlobalGameManager.CanPlayerMove){
            movementLogic();
            jumpLogic();
        }
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){ PauseGame(); }
        IncreaseRagePercent(collidedWithEnemy);
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

    private void PauseGame(){
        if(isOnPause){
            Time.timeScale = 1;
            isOnPause = false;
            pauseUI.SetActive(false);
        } else {
            Time.timeScale = 0;
            isOnPause = true;
            pauseUI.SetActive(true);
        }
        
    }


    private void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name);
        rageBar.GetComponent<PlayerRageBar>().ragePercent += 10;
        Destroy(other.gameObject);
        GetComponentInChildren<ScreenShake>().start = true;
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "EnemyFollower"){
            collidedWithEnemy = true;
        } else{
            collidedWithEnemy = false;
        }
    }

    private void OnCollisionExit(Collision collision){
        if (collision.gameObject.name == "EnemyFollower"){
            collidedWithEnemy = false;
        }
    }

    public void RageZero(){
        SceneManager.LoadScene(4);
    }

    private void IncreaseRagePercent(bool localBool){
        if (localBool){
            rageBar.GetComponent<PlayerRageBar>().ragePercent += 1f;
            collisionWithEnemy.SetActive(true);
        } else{
            collisionWithEnemy.SetActive(false);
        }
        
    }

}