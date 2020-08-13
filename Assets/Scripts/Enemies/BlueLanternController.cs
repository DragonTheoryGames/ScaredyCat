using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLanternController : MonoBehaviour {

    Transform myTransform;

    [Header("Objects")]
    Vector2 rayDirection;
    Vector2 hagDirection;
    Quaternion quaternionAngle;
    LayerMask layerMask;

    [Header("Variables")]
    int randomAngle;
    float x;
    float y;

    float timer;
    float randomDistance;
    float distance;

    Vector2 goal;
    float speed = .12f;

    void Awake() {
        myTransform = GetComponent<Transform>();
        layerMask = ((1 << 14) | (1 << 15));
        timer = Time.time;
    }
    
    void FixedUpdate() {
        if(Time.time > timer) {
            RandomMovement();
        }
        FollowHag();

        myTransform.position = Vector2.MoveTowards(myTransform.position, goal, speed);
    }

    void RandomMovement()
    {
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
        rayDirection = new Vector2(x, y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, Mathf.Infinity, layerMask);
        Debug.DrawRay(transform.position, rayDirection, Color.black, 30f);
        timer += (Random.Range(1, 30));
        randomDistance = Random.Range(1.5f, 4);
        x = (myTransform.position.x + hit.point.x) / 2;
        y = (myTransform.position.y + hit.point.y) / 2;
        goal = new Vector2(x, y);
    }

    void FollowHag(){
        hagDirection = GetComponentInParent<Transform>().position - this.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, hagDirection, Mathf.Infinity, layerMask);
        Debug.DrawRay(transform.position, GetComponentInParent<Transform>().position, Color.blue, 1f);
    }
}
