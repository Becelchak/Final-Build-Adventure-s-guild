using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other objects/ NatureObject(old)")]
public class NatureObject : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Action needAction;
    [SerializeField] private ThreatAndOpportunity? risk;
    [SerializeField] private List<Location> locations;


    public string GetName()
    {
        return name;
    }

    public string GetAction()
    {
        return needAction != null ? $"Требует действие {needAction.ToString()}" : "";
    }

    public string GetRisk()
    {
        return risk != null ? $"При добыче несет риск {risk.ToString()}" : "Не несет риска при добыче";
    }

    public List<Location> GetLocations()
    {
        return locations;
    }
}
