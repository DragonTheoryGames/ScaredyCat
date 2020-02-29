using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Idling animation
    //create platforms

    [Header("GameObjects")]
    [SerializeField] Rigidbody2D myRB;
    [SerializeField] Transform myTransform;
    [SerializeField] Collider2D myCollider;
    [SerializeField] Animator animator; 

    [Header("Variables")]
    private bool isGrounded;
    [SerializeField] private float moveSpeed = 900f;
    [SerializeField] private float jumpSpeed = 10f;
      
    void Update() {
        PlayerRun();
        PlayerJump();
        CheckPlayerVelocity();
        GetActions();
    }

    private void CheckPlayerVelocity() {
        if (myRB.velocity.y > 0) {
            animator.SetBool("isJumping", true);
        }
        else if (myRB.velocity.y < 0) {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
        else if (myRB.velocity.y == 0) {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }

    private void PlayerRun() {
        float x_Move = (Input.GetAxis("Horizontal") * moveSpeed) * Time.fixedDeltaTime;
        if (Mathf.Abs(x_Move) != 0){ //turns player
            myTransform.localScale = new Vector3(Mathf.Sign(x_Move), 1, 1);
            animator.SetBool("isRunning", true);
        }
        else{
            animator.SetBool("isRunning", false);
        }
        myRB.velocity = new Vector2(x_Move, myRB.velocity.y);
    }

    private void PlayerJump() {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))) {
                SendMessage("CreatePlatform");
            }
            else {
                myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            }
        }
    }

    private void GetActions(){
        if (Input.GetKeyDown(KeyCode.F)) {
            SendMessage("SetAttackTalisman");
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            SendMessage("SetEnergyTalisman");
        }
    }
}
