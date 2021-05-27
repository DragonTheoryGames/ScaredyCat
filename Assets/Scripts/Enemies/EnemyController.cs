using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    [SerializeField] GameManager gameManager;
    [SerializeField] public SliderController healthBar;

    [SerializeField] private int health = 30;
    [SerializeField] private int xpValue = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Parent;
    [SerializeField] private PlayerController Player;
    public EnemyPathing pathing;
    bool b;

    [SerializeField] float attack = 15f;

    void Start() {
        pathing = gameObject.GetComponentInParent<EnemyPathing>();
        Player = FindObjectOfType<PlayerController>();
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            animator.SetBool("isDying", true);
            pathing.SetSpeed(0);
            Player.GainXP(xpValue);
        }
        SetIsHurt();
        UpdateHealth();
    }

    public IEnumerator AttackHuman(HumanController Human) {
        pathing.SetSpeed(0);
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1);
        Human.UpdateSanity(attack);
        animator.SetBool("isDying", true);
    }

    public int GetHealth() {
        return health;
    }

    public void SetIsHurt() {
        animator.SetBool("isHurt", true);
    }

    public void KillMePlease() {
        Destroy(Parent.gameObject);
    }

    void UpdateHealth() {
        healthBar.UpdateValue(health);
    }
}