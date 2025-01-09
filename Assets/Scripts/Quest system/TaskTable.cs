using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest system/ TaskTable")]
public class TaskTable : Table
{
    [SerializeField] private List<Task> table;
    public List<Task> GetTable() { return table; }
}
