using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Tables/ ActionTable")]
public class ActionTable : Table
{
    [SerializeField] private List<Action> table;

    public void AddObject(string assetName)
    {
        var actionNew = AssetDatabase.LoadAssetAtPath<Action>($"Assets/Resources/Other/Action/{assetName}.asset");
        if (!table.Contains(actionNew))
        {
            table.Add(actionNew);
        }
    }

    public List<Action> GetTable()
    {
        return table;
    }

    public Action GetObject(string assetName)
    {
        foreach (Action obj in table)
        {
            if (obj.name == assetName)
            {
                return obj;
            }
        }

        return null;
    }
}
