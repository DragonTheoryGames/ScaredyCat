using UnityEngine;

public class Grid : MonoBehaviour {
    
    [SerializeField] bool hasTalisman = false;
    GameObject talisman;

    public void SetTalisman(GameObject tal) {
        if (!hasTalisman){
            hasTalisman = true;
            talisman = tal;
        }
        else if (hasTalisman) {
            Object.Destroy(talisman);
            talisman = tal;
        }
    }
}