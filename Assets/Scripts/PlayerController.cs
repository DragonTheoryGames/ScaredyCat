using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField] Rigidbody2D myRB;
    [SerializeField] Transform myTransform;
    [SerializeField] Collider2D myCollider;
    [SerializeField] Animator animator;
    [SerializeField] Talisman talisman;
    [SerializeField] GameObject talismanMenu;


    [Header("Variables")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float moveSpeed = 900f;
    [SerializeField] private float jumpSpeed = 10f;
    float xMove;
      
    void Update() {
        PlayerRun();
        PlayerJump();
        CheckPlayerVelocity();
        CheckGround();
        CallMenu();
    }

    private void CheckPlayerVelocity() {
        if (myRB.velocity.y > 0) {
            animator.SetBool("isJumping", true);
        }
        else if (myRB.velocity.y < -1.2) {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
        else {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }

    private void CheckGround() {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) && !myCollider.IsTouchingLayers(LayerMask.GetMask("Floor"))) {
            isGrounded = false;
        }
        else {
            isGrounded = true;
        }
    }

    private void PlayerRun() {
        xMove = (Input.GetAxis("Horizontal") * moveSpeed) * Time.fixedDeltaTime;
        if (Mathf.Abs(xMove) != 0) { //turns player
            myTransform.localScale = new Vector3(Mathf.Sign(xMove), 1, 1);
            if (isGrounded) {
                animator.SetBool("isRunning", true);
            }
        }
        else{
            animator.SetBool("isRunning", false);
        }
        myRB.velocity = new Vector2(xMove, myRB.velocity.y);
    }

    private void PlayerJump() {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (!isGrounded) {
                if (xMove != 0) { xMove = Mathf.Sign(xMove) * 3; }
                talisman.CreatePlatform(xMove);
            }
            else {
                myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            }
        }
    }

    //TODO: make this a trigger
    private void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Bed") {
            if (Input.GetKey(KeyCode.S)) {
                Purr(col.gameObject.GetComponent<BedData>());
            }
        }
    }

    private void Purr(BedData bed) {
        //set animation
        bed.owner.UpdateSanity(-1);
        
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
