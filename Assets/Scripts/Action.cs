using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

[CreateAssetMenu(menuName = "Other objects/ Action")]
public class Action : ScriptableObject
{
    // Определяется уже во время этапа планирования
    [SerializeField] private List<InanimateObject> targetAction = new List<InanimateObject>();
    [SerializeField] private List<Location> locationsForWork = new List<Location>();
    [SerializeField] private string name;
    // Определяется уже во время этапа планирования
    [SerializeField] private Human worker;
    // Определяется уже во время этапа планирования
    [SerializeField] private InanimateObject tool;
    // Продуктивность действия
    [SerializeField] private double toolProductivity;
    // Затраты времени на выполнение действия
    [SerializeField] private double timeRequired;
    // Условие для добычи
    [SerializeField] private ScriptableObject? toolCondition;
    // Нейтрализатор. Определяется уже во время этапа планирования
    [SerializeField] private InanimateObject? toolNeutralizer;
    // Определяется уже во время этапа планирования
    [SerializeField] private double toolNeutralizerProductivity;
    // Определяется уже во время этапа планирования
    [SerializeField] private double toolNeutralizerTimeRequired;
    //Условие для использования инструмента нейтрализатора
    [SerializeField] private ScriptableObject? toolNeutralizerCondition;
    // Условие вместе с персонажем
    [SerializeField] private ScriptableObject? сondition;

    [SerializeField] private double coefficient;

    public Action(string name, double toolProductivity, double timeRequired, ScriptableObject toolCondition, ScriptableObject toolNeutralizerCondition, ScriptableObject сondition, double coefficient, double toolNeutralizerProductivity, double toolNeutralizerTimeRequired)
    {
        this.name = name;
        this.toolProductivity = toolProductivity;
        this.timeRequired = timeRequired;
        this.toolCondition = toolCondition;
        this.toolNeutralizerCondition = toolNeutralizerCondition;
        this.toolNeutralizerProductivity = toolNeutralizerProductivity;
        this.toolNeutralizerTimeRequired = toolNeutralizerTimeRequired;
        this.сondition = сondition;
        this.coefficient = coefficient;
    }

    public string GetName()
    {
        return name;
    }

    public List<InanimateObject> GetTargets()
    {
        return targetAction;
    }

    public double GetCoefficient()
    {
        return coefficient;
    }
}
