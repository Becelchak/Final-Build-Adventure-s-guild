using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "Other objects/ InanimateObject")]
public class InanimateObject : ScriptableObject
{
    [SerializeField] private string name;
    // Исчисляемый или неисчисляемый объект
    [SerializeField] private InanimateType inanimateType;
    // В каких локациях находится?
    [SerializeField] private List<Location> locations;

    // Какое действие дает
    [SerializeField] private Action? action;
    // Как улучшает какое-либо действие
    [SerializeField] private double buffCoefficient;

    // Несет угрозу?
    [SerializeField] private ThreatAndOpportunity? threat;
    // Несет возможность?
    [SerializeField] private ThreatAndOpportunity? opportunity;

    // ?????
    //[SerializeField] private double probability;

    //Какое действие требует
    [SerializeField] private Action? needAction;
    // Сколько занимает рук 1 или 2?
    [SerializeField] private int slots;
    // Сколько доступно в квесте?
    [SerializeField] private int numberOfAvailable;

    public InanimateObject(string name, InanimateType type, List<Location> locations, Action? action, double buffCoefficient, ThreatAndOpportunity? threat, ThreatAndOpportunity? opportunity, Action? needAction, int slots, int numberOfAvailable)
    {
        this.name = name;
        this.inanimateType = type;
        this.locations = locations;
        this.action = action;
        this.buffCoefficient = buffCoefficient;
        this.threat = threat;
        this.opportunity = opportunity;
        this.needAction = needAction;
        this.slots = slots;
        this.numberOfAvailable = numberOfAvailable;
    }

    public string GetName()
    {
        return name;
    }

    public string GetAction()
    {
        return action != null ? $"Влияет на действие {action.ToString()}" : "Не влияет на действия";
    }

    public string GetNeedAction()
    {
        return needAction != null ? $"Требует действие {needAction.ToString()}" : "";
    }

    public double GetCoefficient()
    {
        return buffCoefficient;
    }

    public string GetOpportunity()
    {
        return opportunity != null ? $"Дает возможность {opportunity.ToString()}" : "Не является возможностью";
    }

    public string GetThreat()
    {
        return threat != null ? $"Несет в себе риск {threat.ToString()}" : "Не несет в себе риска";
    }

    public List<Location> GetLocations()
    {
        return locations;
    }

    public int GetSlotSize()
    {
        return slots;
    }

    // ?????
    //public double GetProbability()
    //{
    //    return probability;
    //}

    public enum InanimateType
    {
        Calculable = 0,
        Uncountable = 1,
    }
}
