using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEditor;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using UnityEngine.UI;
using static InanimateObject;
using System.Globalization;

public class ObjectCreatorButtonCreate : MonoBehaviour
{
    [SerializeField] private HumanTable humanTable;
    [SerializeField] private HumanTable characters;
    [SerializeField] private AnimalTable animals;
    [SerializeField] private ActionTable actions;
    [SerializeField] private QuestsTable questsTable;
    [SerializeField] private ToolsTable toolNeutralizationTable;
    [SerializeField] private ToolsTable toolTable;
    [SerializeField] private LocationsTable locationTable;
    [SerializeField] private ThreatAndOpportunityTable TAOTable;

    //Common
    [Header("Common")]
    [SerializeField] private string nameObject;
    [SerializeField] private List<Action> listActions = new List<Action>();
    [SerializeField] private bool isTarget;
    [SerializeField] private bool isTO;
    [SerializeField] private bool isFalseTarget;

    // Human
    [Header("Human")]
    [SerializeField] private SerializedDictionary<string, InanimateObject?> slots;
    [SerializeField] private InanimateObject toolNeutralization;
    [SerializeField] private bool isCharacter;
    [SerializeField] private List<Quest> quests = new List<Quest>();
    [SerializeField] private bool isCustomer;

    // Animal
    [Header("Animal")]
    [SerializeField] private ThreatAndOpportunity? TAO;

    // InanimateObject
    [Header("InanimateObject")]
    [SerializeField] private InanimateType inanimateType;
    [SerializeField] private List<Location> locations = new List<Location>();
    [SerializeField] private Action? giveAction;
    [SerializeField] private double buffCoefficient;
    [SerializeField] private ThreatAndOpportunity? threat;
    [SerializeField] private ThreatAndOpportunity? opportunity;
    [SerializeField] private Action? needAction;
    [SerializeField] private int slotsRequire = 1;
    [SerializeField] private int numberOfAvailable;
    [SerializeField] private bool isNeutralizer;

    //Location
    [Header("Location")]
    [SerializeField] private SerializedDictionary<Location, double> locationsDistance;
    private double tempDistance = 1;

    //TAO
    [Header("ThreatAndOpportunity")]
    [SerializeField] private ThreatAndOpportunity.Type typeTAO;
    [SerializeField] private double changeTimeAction;
    [SerializeField] private double changeCount;
    [SerializeField] private InanimateObject neutralizer;
    [SerializeField] private double changeUV;
    [SerializeField] private double probability;
    [SerializeField] private ScriptableObject trigger;

    //Action
    [Header("Action")]
    [SerializeField] private double toolProductivity;
    [SerializeField] private double timeRequired;
    [SerializeField] private ScriptableObject? toolCondition;
    [SerializeField] private ScriptableObject? toolNeutralizerCondition;
    [SerializeField] private ScriptableObject? сondition;
    [SerializeField] private double toolNeutralizerProductivity;
    [SerializeField] private double toolNeutralizerTimeRequired;
    [SerializeField] private double coefficient;

    private TableCanvasContainer tableObjects;

    private void Start()
    {
        tableObjects = GameObject.Find("ContainerTableObjectsMain").GetComponent<TableCanvasContainer>();
    }

    public void CreateObject(TMP_Dropdown dropdownType)
    {
        var typeObject = dropdownType.options[dropdownType.value].text;
        switch (typeObject)
        {
            case "Человек":
                var newHuman = new Human(nameObject, listActions, slots, toolNeutralization, isCharacter, quests, isCustomer, isTarget, isTO, isFalseTarget);
                var newObj = ScriptableObject.CreateInstance<Human>();

                newObj = newHuman;

                if(AssetDatabase.LoadAssetAtPath<Human>($"Assets/Resources/Other/Human/{newObj.GetName()}.asset") == null && newObj.IsCharacter() != "Это персонаж")
                {
                    AssetDatabase.CreateAsset(newObj, $"Assets/Resources/Other/Human/{newObj.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    humanTable.AddHuman(newObj.GetName());
                }
                else if(AssetDatabase.LoadAssetAtPath<Human>($"Assets/Resources/Other/Character/{newObj.GetName()}.asset") == null && newObj.IsCharacter() == "Это персонаж")
                {
                    AssetDatabase.CreateAsset(newObj, $"Assets/Resources/Other/Character/{newObj.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    characters.AddCharacter(newObj.GetName());
                }
                break;
            case "Животное":
                var newAnimal = new Animal(nameObject,listActions, TAO, isTarget, isTO, isFalseTarget);
                var newObj2 = ScriptableObject.CreateInstance<Animal>();
                newObj2 = newAnimal;

                if (AssetDatabase.LoadAssetAtPath<Animal>($"Assets/Resources/Other/Animal/{newObj2.GetName()}.asset") == null)
                {
                    AssetDatabase.CreateAsset(newObj2, $"Assets/Resources/Other/Animal/{newObj2.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    animals.AddAnimal(newObj2.GetName());
                }
                break;
            case "Неживой объект":
                var newInanimateObject = new InanimateObject(nameObject, inanimateType, locations, giveAction, buffCoefficient, threat, opportunity, needAction, slotsRequire, numberOfAvailable);
                var newObj3 = ScriptableObject.CreateInstance<InanimateObject>();
                newObj3 = newInanimateObject;

                if (AssetDatabase.LoadAssetAtPath<InanimateObject>($"Assets/Resources/Other/InanimateObject/{newObj3.GetName()}.asset") == null && !isNeutralizer)
                {
                    AssetDatabase.CreateAsset(newObj3, $"Assets/Resources/Other/InanimateObject/{newObj3.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    toolTable.AddObject(newObj3.GetName());
                }
                else if(AssetDatabase.LoadAssetAtPath<InanimateObject>($"Assets/Resources/Other/InanimateObject/{newObj3.GetName()}.asset") == null && isNeutralizer)
                {
                    AssetDatabase.CreateAsset(newObj3, $"Assets/Resources/Other/InanimateObject/{newObj3.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    toolNeutralizationTable.AddObject(newObj3.GetName());
                }
                break;
            case "Локация":
                var newLocation = new Location(nameObject, isTarget, locationsDistance);
                var newObj4 = ScriptableObject.CreateInstance<Location>();
                newObj4 = newLocation;

                if (AssetDatabase.LoadAssetAtPath<Location>($"Assets/Resources/Other/Location/{newObj4.GetName()}.asset") == null)
                {
                    AssetDatabase.CreateAsset(newObj4, $"Assets/Resources/Other/Location/{newObj4.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    locationTable.AddLocation(newObj4.GetName());
                }
                break;
            case "Угроза или возможность":
                var newTAO = new ThreatAndOpportunity(nameObject, typeTAO, changeTimeAction,changeCount, neutralizer, changeUV, probability, trigger);
                var newObj5 = ScriptableObject.CreateInstance<ThreatAndOpportunity>();
                newObj5 = newTAO;

                if (AssetDatabase.LoadAssetAtPath<ThreatAndOpportunity>($"Assets/Resources/Other/ThreatAndOpportunity/{newObj5.GetName()}.asset") == null)
                {
                    AssetDatabase.CreateAsset(newObj5, $"Assets/Resources/Other/ThreatAndOpportunity/{newObj5.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    TAOTable.AddTAO(newObj5.GetName());
                }
                break;
            case "Работа (Действие)":
                var newAction = new Action(nameObject, toolProductivity, timeRequired, toolCondition, toolNeutralizerCondition, сondition, coefficient, toolNeutralizerProductivity, toolNeutralizerTimeRequired);
                var newObj6 = ScriptableObject.CreateInstance<Action>();
                newObj6 = newAction;

                if (AssetDatabase.LoadAssetAtPath<Action>($"Assets/Resources/Other/Action/{newObj6.GetName()}.asset") == null)
                {
                    AssetDatabase.CreateAsset(newObj6, $"Assets/Resources/Other/Action/{newObj6.GetName()}.asset");
                    AssetDatabase.SaveAssets();
                    actions.AddObject(newAction.GetName());
                }
                break;
            default:
                break;
        }

        tableObjects.RefreshTable();
    }

    public void ChangeName(TMP_InputField newName)
    {
        nameObject = newName.text;
    }

    public void AddAction(TMP_Dropdown dropdown)
    {
        var nameAction = dropdown.options[dropdown.value].text;

        foreach (var action in actions.GetTable())
        {
            if (nameAction == action.GetName())
                listActions.Add(action);
        }
    }

    public void AddQuestAvialable(TMP_Dropdown dropdown)
    {
        var nameQuest = dropdown.options[dropdown.value].text;

        foreach (var quest in questsTable.GetTable())
        {
            if (nameQuest == quest.GetName())
                quests.Add(quest);
        }
    }

    public void ToggleCharacter(Toggle point)
    {
        if (point.isOn)
        {
            isCharacter = true;
        }
        else
            isCharacter = false;
    }

    public void ToggleCustomer(Toggle point)
    {
        if (point.isOn)
        {
            isCustomer = true;
        }
        else
            isCustomer = false;
    }

    public void ToggleTO(Toggle point)
    {
        if (point.isOn)
        {
            isTO = true;
        }
        else
            isTO = false;
    }

    public void ToggleTarget(Toggle point)
    {
        if (point.isOn)
        {
            isTarget = true;
        }
        else
            isTarget = false;
    }

    public void ToggleFalseTarget(Toggle point)
    {
        if (point.isOn)
        {
            isFalseTarget = true;
        }
        else
            isFalseTarget = false;
    }

    public void ChangeSlot(ObjectCreatorSlots slotsInfo)
    {
        var fSlot = slotsInfo.GetFirstSlot();
        var sSlot = slotsInfo.GetSecondSlot();

        slots.Clear();
        slots.Add("Slot 1", fSlot.GetSelectObject());
        slots.Add("Slot 2", sSlot.GetSelectObject());
    }

    public void AddToolNeutralization(TMP_Dropdown dropdown)
    {
        var nameTool = dropdown.options[dropdown.value].text;

        foreach (var tool in toolNeutralizationTable.GetTable())
        {
            if (nameTool == tool.GetName())
                toolNeutralization = tool;
        }
    }

    public void ChangeTAO(ObjectCreatorRisk dropdown)
    {
        TAO = dropdown.GiveSelectObject();
    }

    public void ChangeType(TMP_Dropdown dropdown)
    {
        var nameTool = dropdown.options[dropdown.value].text;
        if(nameTool == "Исчисляемый")
            inanimateType = InanimateType.Calculable;
        else
            inanimateType= InanimateType.Uncountable;
    }

    public void AddLocationInList(TMP_Dropdown dropdown)
    {
        var nameLocation = dropdown.options[dropdown.value].text;

        foreach (var location in locationTable.GetTable())
        {
            if (nameLocation == location.GetName())
                locations.Add(location);
        }
    }

    public void AddGiveAction(TMP_Dropdown dropdown)
    {
        var nameGiveAction = dropdown.options[dropdown.value].text;

        foreach (var action in actions.GetTable())
        {
            if (nameGiveAction == action.GetName())
            {
                giveAction = action;
                break;
            }
            else
                giveAction = null;
        }
    }

    public void ChangeCoefficient(TMP_InputField newName)
    {
        if (newName.text.Contains(","))
            newName.text = newName.text.Replace(',', '.');
        buffCoefficient = double.Parse(newName.text, CultureInfo.InvariantCulture);
    }

    public void AddThreat(TMP_Dropdown dropdown)
    {
        var nameThreat = dropdown.options[dropdown.value].text;

        foreach (var threat in TAOTable.GetTable())
        {
            if (nameThreat == threat.GetName())
            { 
                this.threat = threat;
                break;
            }
            else
                this.threat = null;
        }
    }

    public void AddOpportunity(TMP_Dropdown dropdown)
    {
        var nameOpportunity = dropdown.options[dropdown.value].text;

        foreach (var opportunity in TAOTable.GetTable())
        {
            if (nameOpportunity == opportunity.GetName())
            { 
                this.opportunity = opportunity;
                break;
            }
            else
                this.opportunity = null;
        }
    }

    public void AddNeedAction(TMP_Dropdown dropdown)
    {
        var nameNeedAction = dropdown.options[dropdown.value].text;

        foreach (var action in actions.GetTable())
        {
            if (nameNeedAction == action.GetName())
            {
                needAction = action;
                break;
            }
            else
                needAction = null;
        }
    }

    public void ChangeSlotRequire(int number)
    {
        slotsRequire = number;
    }

    public void ChangeNumberOfAvailable(Slider slider)
    {
        numberOfAvailable = (int)slider.value;
    }

    public void ToggleNeutralizer(Toggle point)
    {
        if (point.isOn)
        {
            isNeutralizer = true;
        }
        else
            isNeutralizer = false;
    }

    public void SetLocationDistance(Slider slider)
    {
        tempDistance = slider.value;
    }

    public void AddLocationDistance(TMP_Dropdown dropdown)
    {
        var nameLocation = dropdown.options[dropdown.value].text;

        foreach (var location in locationTable.GetTable())
        {
            if (nameLocation == location.GetName())
                locationsDistance.Add(location, tempDistance);
        }
    }

    public void ChangeTypeTAO(TMP_Dropdown dropdown)
    {
        var typeName = dropdown.options[dropdown.value].text;
        if (typeName == "Угроза")
            typeTAO = ThreatAndOpportunity.Type.threat;
        else if(typeName == "Возможность")
            typeTAO = ThreatAndOpportunity.Type.opportunity;
    }

    public void ChangeTimeActionCoeff(Slider slider)
    {
        changeTimeAction = (int)slider.value;
    }

    public void ChangeCountCoeff(Slider slider)
    {
        changeCount = (int)slider.value;
    }

    public void AddNeutralizer(TMP_Dropdown dropdown)
    {
        var nameNeutralizer = dropdown.options[dropdown.value].text;
        neutralizer = toolNeutralizationTable.GetObject(nameNeutralizer);
        if(neutralizer == null)
            dropdown.value = 0;
    }

    public void ChangeUVCoeff(Slider slider)
    {
        changeUV = (int)slider.value;
    }

    public void SetProbability(Slider slider)
    {
        probability = (int)slider.value;
    }

    public Dictionary<string, Table> GetTables()
    {
        var dictionaryTables = new Dictionary<string, Table>();
        dictionaryTables.Add("humanTable", humanTable);
        dictionaryTables.Add("characters", characters);
        dictionaryTables.Add("animals", animals);
        dictionaryTables.Add("locationTable", locationTable);
        dictionaryTables.Add("toolTable", toolTable);
        dictionaryTables.Add("toolNeutralizationTable", toolNeutralizationTable);
        return dictionaryTables;
    }

    public void SetTrigger(TMP_Dropdown dropdown)
    {
        var nameTrigger = dropdown.options[dropdown.value].text;

        ScriptableObject temptrigger = toolTable.GetObject(nameTrigger);
        if (temptrigger != null)
            trigger = temptrigger;
        temptrigger = animals.GetObject(nameTrigger);
        if (temptrigger != null)
            trigger = temptrigger;
    }

    public void SetProductivity(Slider slider)
    {
        toolProductivity = (int)slider.value;
    }

    public void SetTimeRequired(Slider slider)
    {
        timeRequired = (int)slider.value;
    }

    public void SetStandartCoefficient(Slider slider)
    {
        coefficient = (int)slider.value;
    }

    public void SetToolNeutralizerProductivity(Slider slider)
    {
        toolNeutralizerProductivity = (int)slider.value;
    }

    public void SetToolNeutralizerTimeRequired(Slider slider)
    {
        toolNeutralizerTimeRequired = (int)slider.value;
    }


    public void AddToolCondition(TMP_Dropdown dropdown)
    {
        var condition = dropdown.options[dropdown.value].text;

        ScriptableObject temptrigger = toolTable.GetObject(condition);
        if (temptrigger != null)
            toolCondition = temptrigger;
        temptrigger = animals.GetObject(condition);
        if (temptrigger != null)
            toolCondition = temptrigger;
    }

    public void AddToolNeutralizerCondition(TMP_Dropdown dropdown)
    {
        var condition = dropdown.options[dropdown.value].text;

        ScriptableObject temptrigger = toolTable.GetObject(condition);
        if (temptrigger != null)
            toolNeutralizerCondition = temptrigger;
        temptrigger = animals.GetObject(condition);
        if (temptrigger != null)
            toolNeutralizerCondition = temptrigger;
    }


    public void AddCondition(TMP_Dropdown dropdown)
    {
        var condition = dropdown.options[dropdown.value].text;

        ScriptableObject temptrigger = toolTable.GetObject(condition);
        if (temptrigger != null)
            this.сondition = temptrigger;
        temptrigger = animals.GetObject(condition);
        if (temptrigger != null)
            this.сondition = temptrigger;
    }
}
