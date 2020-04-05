using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] GridManager grid;
    [SerializeField] public SliderController healthBar;

    [SerializeField] private int health = 10;
    [SerializeField] private Animator animator;
    private EnemyPathing pathing;
    public bool isDying = false;
    bool b;

    [SerializeField] int damage = 15;

    void Start() {
        pathing = gameObject.GetComponent<EnemyPathing>();
        healthBar = GetComponentInChildren<SliderController>();
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            animator.SetBool("isDying", true);
            pathing.speed = 0;
            isDying = true;
            //TODO: make list of attackers to notify upon death.
        }
        UpdateHealth();
    }

    void UpdateHealth(){
        healthBar.UpdateValue(health);
    }

    //TODO: move to Bullet, maybe with a SendMessage
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Bullet") {
            takeDamage(1);
            SetIsHurt(1);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Family") {
            col.gameObject.GetComponent<HumanController>().UpdateSanity(damage);
            KillMePlease();
        }
    }

    public void SetIsHurt(int i) {
        b = (i == 1) ? true : false;
        animator.SetBool("isHurt", b);
    }

    public void KillMePlease() {
        Destroy(this.gameObject);
    }

    public GridManager GetGrid(){
        return grid;
    }

    public void SetGrid(GridManager newGrid){
        grid = newGrid;
    }
}