using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLanternController : MonoBehaviour {

    Transform myTransform;

    [Header("Objects")]
    Vector2 rayDirection;
    Quaternion quaternionAngle;
    LayerMask layerMask;

    [Header("Variables")]
    int randomAngle;
    float x;
    float y;

    float timer;
    float randomDistance;
    float distance;

    Vector2 direction;
    float speed = .12f;

    void Awake() {
        myTransform = GetComponent<Transform>();
        layerMask = ((1 << 14) | (1 << 15));
        timer = Time.time;
    }
    
    void FixedUpdate() {
        if(Time.time > timer){
            randomAngle = Random.Range(0, 360);
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
            rayDirection = new Vector2(x, y);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, Mathf.Infinity, layerMask);
            Debug.DrawRay(transform.position, rayDirection, Color.black, 30f);
            timer += (Random.Range(1, 30));
            randomDistance = Random.Range(.25f,.75f);
            direction = hit.point * randomDistance;
        }

            myTransform.position = Vector2.MoveTowards(myTransform.position, direction, speed);
    }
}
