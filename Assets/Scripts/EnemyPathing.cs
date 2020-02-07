using PathCreation;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    //TODO: make much better pathing, you can do it bro!
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed;
    float distanceTravelled;

    private void Update() {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
        if(distanceTravelled > 130) { //TODO: gross magic numbers yuck/ tempcode 
            Debug.Log("Game Over!"); 
        }
    }
}
