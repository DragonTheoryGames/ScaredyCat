using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D myRB;
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private Collider2D myCollider;
    [SerializeField]
    private Animator animator;

    private bool isGrounded;
    [SerializeField]
    private float moveSpeed = 900f;
    private float jumpSpeed = 15f;

    void FixedUpdate() {
        PlayerRun();
        PlayerJump();
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
        if (Input.GetKeyDown(KeyCode.Space)) {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
        }
    }



    
}
