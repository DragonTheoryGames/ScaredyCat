﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //TODO: be set to properly track enemy location/pathfinding
    const float speed = 1f;
    [SerializeField] public Transform target;
    [SerializeField] AttackTalisman Talisman;

    void FixedUpdate() {
        if (target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
        }
        else {
             Destroy(gameObject);
        }
    }

}
