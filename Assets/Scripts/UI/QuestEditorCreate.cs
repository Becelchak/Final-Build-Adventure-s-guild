using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.GraphicsBuffer;

public class QuestEditorCreate : MonoBehaviour
{
    [SerializeField] private QuestsTable quests;
    [SerializeField] private QuestionTable questions;

    [SerializeField] private TargetTable targetTable;
    [SerializeField] private TaskTable taskTable;
    [SerializeField] private LocationsTable locationTable;
    [SerializeField] private ToolsTable toolTable;
    [SerializeField] private ThreatAndOpportunityTable taoTable;

    //Common
    [Header("Common")]
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int hourInDay;
    [SerializeField] private List<Target> targets = new List<Target>();
    [SerializeField] private List<Task> tasks = new List<Task>();
    [SerializeField] private List<Location> locations = new List<Location>();
    [SerializeField] private List<InanimateObject> tools = new List<InanimateObject>();
    [SerializeField] private List<ThreatAndOpportunity> tao = new List<ThreatAndOpportunity>();
    public void CreateNewQuest()
    {
        var newQuest = new Quest(name, description, hourInDay, locations, targets, tasks, tools, tao, questions);
        var newObj = ScriptableObject.CreateInstance<Quest>();
        newObj = newQuest;

        if (AssetDatabase.LoadAssetAtPath<Quest>($"Assets/Resources/Other/Quest system/Quests/{newObj.GetName()}.asset") == null)
        {
            AssetDatabase.CreateAsset(newObj, $"Assets/Resources/Other/Quest system/Quests/{newObj.GetName()}.asset");
            AssetDatabase.SaveAssets();
            quests.AddQuest(newObj);

        }
    }

    public void ChangeNameQuest(TMP_InputField newName)
    {
        name = newName.text;
        
    }

    public void ChangeDescriptionQuest(TMP_InputField newDescription)
    {
        description = newDescription.text;
    }

    public void SetHourInDay(Slider slider)
    {
        hourInDay = (int)slider.value;
    }

    public void AddTargets(TMP_Dropdown dropdown)
    {
        var nameTarget = dropdown.options[dropdown.value].text;

        foreach (var target in targetTable.GetTable())
        {
            if (nameTarget == target.name && !targets.Contains(target))
            {
                targets.Add(target);
                break;
            }
        }
    }

    public void AddTasks(TMP_Dropdown dropdown)
    {
        var nameTask = dropdown.options[dropdown.value].text;

        foreach (var task in taskTable.GetTable())
        {
            if (nameTask == task.name && !tasks.Contains(task))
            {
                tasks.Add(task);
                break;
            }
        }
    }

    public void AddLocations(TMP_Dropdown dropdown)
    {
        var nameLocation = dropdown.options[dropdown.value].text;

        foreach (var location in locationTable.GetTable())
        {
            if (nameLocation == location.name && !locations.Contains(location))
            {
                locations.Add(location);
                break;
            }
        }
    }

    public void AddTools(TMP_Dropdown dropdown)
    {
        var nameTool = dropdown.options[dropdown.value].text;

        foreach (var tool in toolTable.GetTable())
        {
            if (nameTool == tool.name && !tools.Contains(tool))
            {
                tools.Add(tool);
                break;
            }
        }
    }

    public void AddTAO(TMP_Dropdown dropdown)
    {
        var nameTAO = dropdown.options[dropdown.value].text;

        foreach (var taoItem in taoTable.GetTable())
        {
            if (nameTAO == taoItem.name && !tao.Contains(taoItem))
            {
                tao.Add(taoItem);
                break;
            }
        }
    }

    public void AddQuestionTable(TMP_Dropdown dropdown)
    {
        var nameTable = dropdown.options[dropdown.value].text;
        var table = AssetDatabase.LoadAssetAtPath<QuestionTable>($"Assets/Resources/Other/Quest system/Questions/{nameTable}.asset");
        if (table != null)
            questions = table;
    }
}
