using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Tables/ HumanTable")]
public class HumanTable : Table
{
    [SerializeField] private List<Human> table;

    public void AddHuman(string assetName)
    {
        var humanNew = AssetDatabase.LoadAssetAtPath<Human>($"Assets/Resources/Other/Human/{assetName}.asset");
        if(!table.Contains(humanNew))
        {
            table.Add(humanNew);
        }
    }

    public void AddCharacter(string assetName)
    {
        var characterNew = AssetDatabase.LoadAssetAtPath<Human>($"Assets/Resources/Other/Character/{assetName}.asset");
        if (!table.Contains(characterNew))
        {
            table.Add(characterNew);
        }
    }

    public List<Human> GetTable() { return table; }
}
