using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D myRB;
    [SerializeField]
    private isGrounded isGrounded;

    private float moveSpeed = 15f;
    private float jumpSpeed = 15f;

    void FixedUpdate() {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove() {
        float x_Move = Input.GetAxis("Horizontal") * moveSpeed;
        myRB.velocity = new Vector2(x_Move, myRB.velocity.y);
    }

    private void PlayerJump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
        }
    }

    
}
