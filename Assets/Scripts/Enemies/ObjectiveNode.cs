using System.Collections.Generic;
using UnityEngine;

public class ObjectiveNode : MonoBehaviour {
    
    [SerializeField] List<Transform> nextObjectiveNode;

    public Transform ReturnNextObjectiveNode() {
        int nextObj = Random.Range(0, nextObjectiveNode.Count);
            return nextObjectiveNode[nextObj];
    }
}
