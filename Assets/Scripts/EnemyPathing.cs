using System;
using PathCreation;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    public float speed = 100;
    [SerializeField] Transform nextobjective;
    
    [Header("Transform")]
    Transform myTransform;
    float direction;
    float myX;
    float myY;

    private void Start() {
        myTransform = gameObject.GetComponent<Transform>();
        myX = myTransform.localScale.x;
        myY = myTransform.localScale.y;
    }

    private void FixedUpdate() {
        Move();
        FaceEnemy();
    }

    void Move() {
        transform.position = Vector2.MoveTowards(transform.position, nextobjective.position, speed);
    }

    private void FaceEnemy() { //turns enemy
        direction = Mathf.Sign(nextobjective.TransformPoint(Vector2.zero).x - myTransform.TransformPoint(Vector2.zero).x);
        myTransform.localScale = new Vector3((myX * direction), myY, 0);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.transform == nextobjective) {
            nextobjective = col.GetComponent<ObjectiveNode>().ReturnNextObjectiveNode();
        }
    }

    public void Setnextobjective(Transform newObjective){
        nextobjective = newObjective;
    }
}
