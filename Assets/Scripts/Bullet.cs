using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //TODO: be set to properly track enemy location/pathfinding
    //TODO: Bullets need to kill themselves
    [SerializeField] float xVelocity = 5;

    void FixedUpdate() {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-xVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
}
