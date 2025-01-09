using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other objects/ Animal")]
public class Animal : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private List<Action> actions = new List<Action>();
    [SerializeField] private ThreatAndOpportunity? risk;
    [SerializeField] private bool isTarget;
    // Это УВ?
    [SerializeField] private bool isTO;
    [SerializeField] private bool isFalseTarget;


    public Animal(string name, List<Action> actions, ThreatAndOpportunity risk, bool isTarget, bool isTO, bool isFalseTarget)
    {
        this.name = name;
        this.actions = actions;
        this.risk = risk;
        this.isTarget = isTarget;
        this.isTO = isTO;
        this.isFalseTarget = isFalseTarget;
    }

    public string GetName()
    {
        return name;
    }

    public List<Action> GetActions()
    {
        return actions;
    }

    public string GetRisk()
    {
        return risk != null ? risk.ToString() : "Нет рисков";
    }
}
