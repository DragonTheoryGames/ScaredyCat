using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTalisman : MonoBehaviour {
    
    [SerializeField] Bullet bullet;
    [SerializeField] Transform target = null;
    GridManager gridManager;
    float talismanX;
    float talismanY;

    void Start(){
        talismanX = GetComponent<Transform>().TransformPoint(Vector2.zero).x;
        talismanY = GetComponent<Transform>().TransformPoint(Vector2.zero).y;
    }

    public void FireBullet() { //called from animation
        FindTarget();
        if (target != null) {
            Instantiate(bullet, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().SetTalisman(GetComponent<AttackTalisman>());
        }
        
    }

    public void SetGridManager(GridManager parentGridManager){
        gridManager = parentGridManager;
    }

    public void FindTarget() {
        if (target == null) {
            Debug.Log(target);
            List<EnemyController> enemies = gridManager.GetEnemies();
            float enemyDistance = 0;

            if (enemies.Count <= 0) {
                return;
            }
            foreach (EnemyController enemy in enemies) { //replace with a raycast.
                Transform enemyTransform = enemy.GetComponent<Transform>();
    
                float enemyX = enemyTransform.TransformPoint(Vector2.zero).x;
                float enemyY = enemyTransform.TransformPoint(Vector2.zero).y;

                float diffX = talismanX - enemyX;
                float diffY = talismanY - enemyY;

                float distance = Mathf.Abs(diffX) + Mathf.Abs(diffY);
                if (target == null) {
                    target = enemyTransform;
                    enemyDistance = distance;
                    
                }
                else if(distance < enemyDistance) {
                    target = enemyTransform;
                    enemyDistance = distance;
                }
            }
        }
    }

    public Transform GetTarget() {
        return target;
    }
}
