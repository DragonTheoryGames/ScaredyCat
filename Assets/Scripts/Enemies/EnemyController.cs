using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] GameManager gameManager;
    [SerializeField] public SliderController healthBar;

    [SerializeField] private int health = 30;
    [SerializeField] private int xpValue = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Parent;
    [SerializeField] private PlayerController Player;
    public EnemyPathing pathing;
    public bool isDying = false;
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
            isDying = true;
        }
        SetIsHurt();
        UpdateHealth();
    }

    public void AttackHumans(HumanController Human){
        Human.UpdateSanity(attack);
        KillMePlease();
    }

    public int GetHealth() {
        return health;
    }

    public void SetIsHurt() {
        animator.SetBool("isHurt", b);
    }

    public void KillMePlease() {
        Destroy(Parent.gameObject);
    }

    void UpdateHealth() {
        healthBar.UpdateValue(health);
    }
}