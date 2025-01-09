using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Other objects/ ThreatAndOpportunity")]
public class ThreatAndOpportunity : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Type typeObject;

    //Воздействие на затраты времени
    [SerializeField] private double changeTimeAction;
    //Влияние на количество
    [SerializeField] private double changeCount;
    // Инструмент НА
    [SerializeField] private InanimateObject neutralizer;
    // Коэффицент воздействия на влияние УВ ???
    [SerializeField] private double changeUV;
    //Коэффицент на вероятность появления
    [SerializeField] private double probability;
    // Персонаж воздействия
    [SerializeField] private ScriptableObject trigger;


    public ThreatAndOpportunity(string name, Type typeObject, double changeTimeAction, double changeCount, InanimateObject neutralizer, double changeUV, double probability, ScriptableObject trigger)
    {
        this.name = name;
        this.typeObject = typeObject;
        this.changeTimeAction = changeTimeAction;
        this.changeCount = changeCount;
        this.neutralizer = neutralizer;
        this.changeUV = changeUV;
        this.probability = probability;
        this.trigger = trigger;
    }
    public string GetName()
    {
        return name;
    }

    public enum Type{
        threat = 0,
        opportunity = 1,
    }
}
