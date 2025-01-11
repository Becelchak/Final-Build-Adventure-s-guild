using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Tables/ AnimalTable")]
public class AnimalTable : Table
{
    [SerializeField] private List<Animal> table;

    public void AddAnimal(string assetName)
    {
        var animalNew = Resources.Load<Animal>($"Other/Animal/{assetName}");
        if (!table.Contains(animalNew))
        {
            table.Add(animalNew);
        }
    }

    public List<Animal> GetTable() { return table; }

    public Animal GetObject(string assetName)
    {
        foreach (Animal obj in table)
        {
            if (obj.name == assetName)
            {
                return obj;
            }
        }

        return null;
    }
}
