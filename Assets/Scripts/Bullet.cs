using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //TODO: be set to properly track enemy location/pathfinding
    //TODO: Bullets need to kill themselves
    [SerializeField] float speed = .00000000001f;
    [SerializeField] Transform target;
    [SerializeField] AttackTalisman Talisman;

    void FixedUpdate() {
        if (Talisman == null){
            Destroy(gameObject);
        }
        else if (target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
        }
        else if (Talisman != null && Talisman.GetTarget() != null) {
            target = Talisman.GetTarget();
        }
        else {
             Destroy(gameObject);
        }
    }

    public void SetTalisman(AttackTalisman attackTalisman){
        Talisman = attackTalisman;
    }

}
