using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //TODO: be set to properly track enemy location/pathfinding
    const float speed = .1f;
    [SerializeField] Transform target;
    [SerializeField] AttackTalisman Talisman;

    void FixedUpdate() {
        if (Talisman == null){
            Destroy(this.gameObject);
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
