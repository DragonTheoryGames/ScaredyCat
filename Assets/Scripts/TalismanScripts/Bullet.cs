using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    const float speed = 1f;
    [SerializeField] public Transform target;
    [SerializeField] AttackTalisman Talisman;

    [Header("String Commands")]
    string enemyTag = "Enemy";

    void FixedUpdate() {
        if (target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == enemyTag) {
            col.gameObject.GetComponentInChildren<EnemyController>().takeDamage(1);
            Destroy(this.gameObject);
        }
    }

}
