using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(menuName = "Quest system/ QuestsTable")]
public class QuestsTable : ScriptableObject
{
    [SerializeField] private List<Quest> table;
    public List<Quest> GetTable() { return table; }

    public void AddQuest(Quest quest)
    {
        table.Add(quest);
    }
}
