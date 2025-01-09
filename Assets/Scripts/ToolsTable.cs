using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Tables/ ToolsTable")]
public class ToolsTable : Table
{
    [SerializeField] private List<InanimateObject> table;

    public void AddObject(string assetName)
    {
        var toolNew = AssetDatabase.LoadAssetAtPath<InanimateObject>($"Assets/Resources/Other/InanimateObject/{assetName}.asset");
        if (!table.Contains(toolNew))
        {
            table.Add(toolNew);
        }
    }

    public List<InanimateObject> GetTable()
    {
        return table;
    }

    public InanimateObject GetObject(string assetName)
    {
        foreach (InanimateObject obj in table)
        {
            if (obj.name == assetName)
            {
                return obj;
            }
        }

        return null;
    }
}
