using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Other objects/ Human")]
public class Human : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private List<Action> actions = new List<Action>();
    [SerializeField] private SerializedDictionary<string, InanimateObject?> tools = new() { {"Slot 1", null } , { "Slot 2", null } };
    [SerializeField] private InanimateObject? riskTool;
    [SerializeField] private bool isCharacter;

    // Возможны пересечения с параметром characters в классе QuestJournal
    [SerializeField] private List<Quest> availableInQuests = new List<Quest>();

    // Charactet sheet
    [SerializeField] private bool isCustomer;
    [SerializeField] private bool isTarget;
    // Это УВ?
    [SerializeField] private bool isTO;
    [SerializeField] private bool isFalseTarget;
    public Human(string name, List<Action> actions, SerializedDictionary<string, InanimateObject?> tools, InanimateObject? riskTool, bool isCharacter, List<Quest> availableInQuests, bool isCustomer, bool isTarget, bool isTO, bool isFalseTarget)
    {
        this.name = name;
        this.actions = actions;    
        this.tools = tools;
        this.riskTool = riskTool;
        this.isCharacter = isCharacter;
        this.availableInQuests = availableInQuests;
        this.isCustomer = isCustomer;
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

    public string GetTool()
    {
        //tools = Tuple.Create(new InanimateObject(), new InanimateObject());

        var slotFirst = tools["Slot 1"] != null ? tools["Slot 1"].GetName() : "Нет инструмента";
        var slotSecond = tools["Slot 2"] != null ? tools["Slot 2"].GetName() : "Нет инструмента";
        return $"В первом слоте {slotFirst}. Во втором слоте {slotSecond}";
    }

    public string GetRiskTool()
    {
        return riskTool != null ? riskTool.GetName() : "Нет нейтрализатора риска";
    }

    public string IsCharacter()
    {
        return isCharacter == true ? "Это персонаж" : "Это не персонаж" ;
    }

    public List <Quest> GetAvailableInQuests()
    {
        return availableInQuests;
    }
}
