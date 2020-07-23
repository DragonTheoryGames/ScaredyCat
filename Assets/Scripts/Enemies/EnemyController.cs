using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] public SliderController healthBar;

    [SerializeField] private int health = 30;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Parent;
    public EnemyPathing pathing;
    public bool isDying = false;
    bool b;

    [SerializeField] float attack = 15f;

    void Start() {
        pathing = gameObject.GetComponentInParent<EnemyPathing>();
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            animator.SetBool("isDying", true);
            pathing.SetSpeed(0);
            isDying = true;
        }
        SetIsHurt(1);
        UpdateHealth();
    }

    public void AttackHumans(HumanController Human){
        Human.UpdateSanity(attack);
        KillMePlease();
    }

    public int GetHealth() {
        return health;
    }

    void UpdateHealth(){
        healthBar.UpdateValue(health);
    }

    public void SetIsHurt(int i) {
        b = (i == 1) ? true : false;
        animator.SetBool("isHurt", b);
    }

    public void KillMePlease() {
        Destroy(Parent.gameObject);
    }
}