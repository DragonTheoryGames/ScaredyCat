using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField] Rigidbody2D myRB;
    [SerializeField] Transform myTransform;
    [SerializeField] Collider2D myCollider;
    [SerializeField] Animator animator;
    [SerializeField] Animator lightAnimator;
    [SerializeField] Talisman talisman;
    [SerializeField] GameObject talismanMenu;
    [SerializeField] BedData currentBed;


    [Header("Variables")]
    [SerializeField] private bool isGrounded;
    private float coyoteTime;
    private bool coyoteTimeBool = false;
    [SerializeField] private float moveSpeed = 900f;
    [SerializeField] private float jumpSpeed = 10f;
    float xMove;
    [SerializeField] float fallGravity;
    [SerializeField] float lowJumpGravity;
    [SerializeField] bool isOnBed = false;
    [SerializeField] bool ispurring = false;

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
            animator.SetBool("isJumping", true);
            lightAnimator.SetBool("isJumping", true);
        }
        else if (myRB.velocity.y < -1.2) {
            animator.SetBool("isFalling", true);
            lightAnimator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
            lightAnimator.SetBool("isJumping", false);
        }
        else {
            animator.SetBool("isJumping", false);
            lightAnimator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            lightAnimator.SetBool("isFalling", false);
        }
    }

    private void CheckGround() {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) && !myCollider.IsTouchingLayers(LayerMask.GetMask("Floor"))) {
            isGrounded = false;
            
        }
        else {
            isGrounded = true;
            coyoteTime = Time.fixedTime;
        }
    }

    private void PlayerRun() {
        xMove = (Input.GetAxis("Horizontal") * moveSpeed) * Time.fixedDeltaTime;
        if (Mathf.Abs(xMove) != 0) { //turns player
            myTransform.localScale = new Vector3(Mathf.Sign(xMove), 1, 1);
            if (isGrounded) {
                animator.SetBool("isRunning", true);
                lightAnimator.SetBool("isRunning", true);
            }
        }
        else{
            animator.SetBool("isRunning", false);
            lightAnimator.SetBool("isRunning", false);
        }
        myRB.velocity = new Vector2(xMove, myRB.velocity.y);
    }

    private void PlayerJump() {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (!isGrounded && Time.fixedTime > coyoteTime + .1f) {
                coyoteTime = 0;
                if (xMove != 0) { xMove = Mathf.Sign(xMove) * 3; }
                talisman.CreatePlatform(xMove);
            }
            else {
                
                myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Bed") {
            currentBed = col.gameObject.GetComponent<BedData>();
            isOnBed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col){
        if (col.gameObject.tag == "Bed") {
            currentBed = null;
            isOnBed = false;
        }
    }

    private void Purr() {
        //set animation
        if (Input.GetKeyDown(KeyCode.S) && isOnBed){
            ispurring = true;
            animator.SetBool("isPurring", true);
            lightAnimator.SetBool("isPurring", true);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)){
            ispurring = false;
            animator.SetBool("isPurring", false);
            lightAnimator.SetBool("isPurring", false);
        }
        if (ispurring){
            currentBed.owner.UpdateSanity(-1 * Time.deltaTime);
        }
    }

    void CallMenu() {
        if (Input.GetKey(KeyCode.F) && isGrounded) {
            talismanMenu.SetActive(true);
        }
        else {
            talismanMenu.SetActive(false);
        }
    }
}
