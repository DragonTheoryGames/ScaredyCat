using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] private int health = 10;
    [SerializeField] private Animator animator;
    bool b;

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            animator.SetBool("isDying", true);
        }
    }

    //TODO: move to Bullet, maybe with a SendMessage
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Bullet") {
            takeDamage(1);
            SetIsHurt(1);
            Destroy(col.gameObject);
        }
    }

    public void SetIsHurt(int i) {
        b = (i == 1) ? true : false;
        animator.SetBool("isHurt", b);
    }

    public void KillMePlease() {
        Destroy(this.gameObject);
    }
}