using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StatManager : MonoBehaviour
{
    [SerializeField] public List<Stat> stats;

    public void set(string name, float val) {
        stats.Find(x => name.Equals(x)).VALUE = val;
    }
    
}

[System.Serializable]
public class Stat {
    [SerializeField] public string NAME = "DEFAULT";
    [SerializeField] public float VALUE = 0f;
}
