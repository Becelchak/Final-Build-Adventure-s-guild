using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest system/ TargetTable")]
public class TargetTable : Table
{
    [SerializeField] private List<Target> table;
    public List<Target> GetTable() { return table; }
}
