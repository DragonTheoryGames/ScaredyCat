using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptablePower", menuName = "ScriptablePower")]
public class _ScriptablePowers : ScriptableObject {

    public string powerName;
    [TextArea(5,10)]
    public string powerDescription;
    public string powerattribute;
    public int value;
}
