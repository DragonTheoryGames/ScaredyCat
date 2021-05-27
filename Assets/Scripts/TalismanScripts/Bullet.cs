using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float speed = .5f;
    [SerializeField] public Transform target;
    [SerializeField] Transform myTransform;
    [SerializeField] AttackTalisman Talisman;
    [SerializeField] Animator animator;
    Vector2 position = new Vector2(0,0);
    int rot;

    [Header("String Commands")]
    string enemyTag = "Enemy";

    void Start() {
        myTransform = this.transform;
    }


    void FixedUpdate() {
        Movement();
    }

    private void Movement() {
        int dir;
        if (target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
            dir = target.position.x > transform.position.x ? -1 : 1;
            position = transform.position;
            FaceFireball(dir, rot);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        int bonusDamage = PowersManager.summerPower;
        if (col.gameObject.tag == enemyTag) {
            col.gameObject.GetComponentInChildren<EnemyController>().takeDamage(1 + bonusDamage);
            FireballAnimation();
            
        }
    }

    private void FaceFireball(int dir, float rot) {
        myTransform.localScale = new Vector3(Mathf.Sign(dir), 1, 1);
        myTransform.localRotation = Quaternion.Euler(0,0,rot);
    }

    void FireballAnimation() {
        animator.SetBool("Boom", true);
    }

    public void KillMe(){
        Destroy(this.gameObject);
    }

}
