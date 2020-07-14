using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableLevel", menuName = "ScriptableLevel", order = 1)]
public class _SriptableLevel : ScriptableObject {
    public string levelName;
    public int enemyCount;
    public int enemySpawnTime;
    public int enemySpawners;
    public int nextStage;
}
