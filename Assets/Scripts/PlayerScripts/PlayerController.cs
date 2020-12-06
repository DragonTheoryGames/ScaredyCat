using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField] Rigidbody2D myRB;
    [SerializeField] Transform myTransform;
    [SerializeField] Collider2D myCollider;
    [SerializeField] Animator animator;
    [SerializeField] Talisman talisman;
    [SerializeField] GameObject talismanMenu;
    [SerializeField] HumanController currentBed;
    [SerializeField] Transform playerHUD;
    LayerMask layerMask;

    [Header("Variables")]
    [SerializeField] private bool isGrounded = true;
    [SerializeField] bool queuedJump = false;
    private float coyoteTime;
    private bool coyoteTimeBool = false;
    [SerializeField] private float moveSpeed = 900f;
    [SerializeField] private float jumpSpeed = 10f;
    float xMove;
    [SerializeField] float fallGravity;
    [SerializeField] float lowJumpGravity;
    [SerializeField] bool isOnBed = false;
    [SerializeField] bool isCatPurring = false;

    [Header("String Commands")]
    string horizontal = "Horizontal";
    string jump = "Jump";
    string interact = "Fire1";
    string action = "Fire2";
    string isJumping = "isJumping";
    string isFalling = "isFalling";
    string platform = "Platform";
    string floor = "Floor";
    
    string isRunning = "isRunning";
    string bed = "Bed";
    string isPurring = "isPurring";
    string currentStageKey = "CurrentStage";

    void Awake() {
        layerMask = ((1 << 8) | (1 << 15));
    }

    void Update() {
        PlayerRun();
        PlayerJump();
        CheckPlayerVelocity();
        CheckGround();
        CallMenu();
        ControlGravity();
        Purr();
    }

    private void ControlGravity() {
        if (!isGrounded) {
            if (myRB.velocity.y < 0) {
                myRB.velocity += Vector2.up * Physics2D.gravity.y * (fallGravity - 1) * Time.deltaTime;
            }
            else if (myRB.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
                myRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravity - 1) * Time.deltaTime;
            }
        }
        
    }

    private void CheckPlayerVelocity() {
        if (myRB.velocity.y > 0) {
            animator.SetBool(isJumping, true);
        }
        else if (myRB.velocity.y < -1.2) {
            animator.SetBool(isFalling, true);
            animator.SetBool(isJumping, false);
        }
        else {
            animator.SetBool(isJumping, false);
            animator.SetBool(isFalling, false);
        }
    }

    private void CheckGround() {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask(platform)) && !myCollider.IsTouchingLayers(LayerMask.GetMask(floor))) {
            isGrounded = false;
        }
        else {
            isGrounded = true;
            coyoteTime = Time.fixedTime;
        }
    }

    private void PlayerRun() {
        xMove = (Input.GetAxis(horizontal) * moveSpeed) * Time.fixedDeltaTime;
        if (Mathf.Abs(xMove) != 0) { //turns player
            myTransform.localScale = new Vector3(Mathf.Sign(xMove), 1, 1);
            if (isGrounded) {
                animator.SetBool(isRunning, true);
            }
        }
        else{
            animator.SetBool(isRunning, false);
        }
        myRB.velocity = new Vector2(xMove, myRB.velocity.y);
    }

    private void PlayerJump() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 100, layerMask);
        Debug.DrawRay(transform.position, new Vector3(0,-100,0), Color.black, .5f);
        if (Input.GetButtonDown(jump)){
            if (!isGrounded && Time.fixedTime > coyoteTime + .1f && hit.distance > 3) {
                coyoteTime = 0;
                if (xMove != 0) { xMove = Mathf.Sign(xMove) * 3; }
                talisman.CreatePlatform(xMove); 
            }
            else if (hit.distance < 3) {
                    queuedJump = true;
            }
            if (isGrounded){
                myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            }
        }
        if (queuedJump && isGrounded) {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            queuedJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == bed) {
            currentBed = col.gameObject.GetComponent<HumanController>();
            isOnBed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == bed) {
            currentBed = null;
            isOnBed = false;
        }
    }

    private void Purr() {
        //set animation
        if (Input.GetKeyDown(KeyCode.S) && isOnBed) {
            isCatPurring = true;
            animator.SetBool(isPurring, true);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)){
            isCatPurring = false;
            animator.SetBool(isPurring, false);
        }
        if (isCatPurring){
            currentBed.UpdateSanity(-1 * Time.deltaTime);
        }
    }

    void CallMenu() {
        playerHUD.position = myTransform.position;
        if (Input.GetButton(action) && isGrounded) {
            talismanMenu.SetActive(true);
        }
        else {
            talismanMenu.SetActive(false);
        }
    }
}
