using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Tables/ LocationsTable")]
public class LocationsTable : Table
{
    [SerializeField] private List<Location> table;
    public void AddLocation(string assetName)
    {
        var locationNew = AssetDatabase.LoadAssetAtPath<Location>($"Assets/Resources/Other/Location/{assetName}.asset");
        if (!table.Contains(locationNew))
        {
            table.Add(locationNew);
        }

    }

    public List<Location> GetTable() { return table; }
}
