using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTalisman : MonoBehaviour {
    
    [SerializeField] Bullet bullet;

    public void FireBullet() {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
