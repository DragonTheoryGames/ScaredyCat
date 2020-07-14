using UnityEngine;

public class AttackTalisman : MonoBehaviour {
    
    [SerializeField] Bullet bullet;
    Bullet myBullet;
    [SerializeField] Transform target;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float lastTime = 0;
    [SerializeField] float attackTime = 3;

    void Start(){
        layerMask = ((1 << 11) | (1 << 14) | (1 << 15));
        InvokeRepeating("FireBullet", 0f, 3f);
    }

    public void FireBullet() {
        FindTarget();
        if (target != null) {
            myBullet = Instantiate(bullet, transform.position, transform.rotation);
            myBullet.GetComponent<Bullet>().target = target;
        } 
    }

    private void FindTarget() {
        bool currentTargetInRange = false;
        float shortestDistance = Mathf.Infinity;
        Transform tempTarget = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 rayDirection = Vector3.zero;
        foreach (GameObject enemy in enemies) {
            rayDirection = enemy.transform.position - this.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, Mathf.Infinity, layerMask);
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (hit.collider.tag == "Enemy") {
                Debug.DrawRay(transform.position, rayDirection, Color.black, 1.5f);
                float dist = Vector3.Distance(this.transform.position, enemy.transform.position);
                if (dist < shortestDistance) {
                    shortestDistance = dist;
                    tempTarget = enemy.transform;
                }
                Debug.DrawRay(transform.position, rayDirection, Color.green, .5f);
                if (target != null) {
                    if (hit.collider.gameObject.name == target.gameObject.name) {
                        currentTargetInRange = true;                    
                    }
                }
            }
            else {
                Debug.DrawRay(transform.position, rayDirection, Color.red, 1.5f);
            }
        }
        if (currentTargetInRange == false) {
            target = null;
        }
        if (target == null || target.GetComponentInChildren<EnemyController>().GetHealth() <= 0) {
            target = tempTarget;
        }
    }
}