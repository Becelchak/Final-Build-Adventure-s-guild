using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other objects/ NaturesEvent(old)")]
public class NaturesEvent : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private double probability;
    [SerializeField] private ThreatAndOpportunity? risk;

    public string GetName()
    {
        return name;
    }

    public double GetProbability()
    {
        return probability;
    }
}
