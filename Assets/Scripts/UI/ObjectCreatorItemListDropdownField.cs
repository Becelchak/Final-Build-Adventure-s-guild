using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ObjectCreatorItemListDropdownField : MonoBehaviour
{
    [SerializeField] private string NameSelectItem;
    [SerializeField] private GameObject prefabe;

    [SerializeField] private string pathFolder = "Assets/Resources/Other/QuestJournal system/Quests";
    [SerializeField] private Table table;
    [SerializeField] private CategoryTable category;
    private TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        if (table != null)
        {
            switch (category)
            {
                case CategoryTable.tool:
                    var toolTable1 = table as ToolsTable;
                    foreach (var item in toolTable1.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }
                    break;
                case CategoryTable.human:
                    var humanTable = table as HumanTable;
                    foreach (var item in humanTable.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }
                    break;
                case CategoryTable.animal:
                    var animalTable = table as AnimalTable;
                    foreach (var item in animalTable.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }
                    break;
                case CategoryTable.location:
                    var locationTable = table as LocationsTable;
                    foreach (var item in locationTable.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }
                    break;
                case CategoryTable.target:
                    var targetTable = table as TargetTable;
                    foreach (var item in targetTable.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }
                    break;
                case CategoryTable.task:
                    var taskTable = table as TaskTable;
                    foreach (var item in taskTable.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }
                    break;
                case CategoryTable.TAO:
                    var taoTable = table as ThreatAndOpportunityTable;
                    foreach (var item in taoTable.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }
                    break;
                case CategoryTable.all:
                    var dictionaryTable = GameObject.Find("ButtonCreateThreatAdnOpportunity").GetComponent<ObjectCreatorButtonCreate>().GetTables();
                    toolTable1 = dictionaryTable["toolTable"] as ToolsTable;
                    //var toolTable2 = dictionaryTable["toolNeutralizationTable"] as ToolsTable;
                    //humanTable = dictionaryTable["humanTable"] as HumanTable;
                    //var humanTable2 = dictionaryTable["characters"] as HumanTable;
                    animalTable = dictionaryTable["animals"] as AnimalTable;
                    //locationTable = dictionaryTable["locationTable"] as LocationsTable;
                    foreach (var item in toolTable1.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }

                    //foreach (var item in toolTable2.GetTable())
                    //{
                    //    dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    //}

                    //foreach (var item in humanTable.GetTable())
                    //{
                    //    dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    //}

                    //foreach (var item in humanTable2.GetTable())
                    //{
                    //    dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    //}

                    foreach (var item in animalTable.GetTable())
                    {
                        dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    }

                    //foreach (var item in locationTable.GetTable())
                    //{
                    //    dropdown.options.Add(new TMP_Dropdown.OptionData(item.name));
                    //}
                    break;
                default:
                    break;
            }

        }
        else
        {
            var directory = new DirectoryInfo(pathFolder);
            var files = directory.GetFiles("*.asset");
            foreach (var file in files)
            {
                var name = file.Name.Split('.')[0];
                if (!name.Contains("Table"))
                    dropdown.options.Add(new TMP_Dropdown.OptionData(name));
            }
        }
        
    }

    public void AddItemInList()
    {
        NameSelectItem = dropdown.options[dropdown.value].text;

        if (NameSelectItem == "") return;

        var inst = GameObject.Instantiate(prefabe);
        var par = prefabe.transform.parent;
        var container = par.GetComponentInChildren<GridLayoutGroup>().gameObject;
        inst.name = NameSelectItem;
        inst.transform.SetParent(container.transform);

        inst.GetComponentInChildren<Text>().text = NameSelectItem;

        var canvasGroupe = inst.GetComponent<CanvasGroup>();
        canvasGroupe.alpha = 1;
        canvasGroupe.blocksRaycasts = true;
        canvasGroupe.interactable = true;

    }

    public void AddItemInListLocationDistance(Slider slider)
    {
        NameSelectItem = dropdown.options[dropdown.value].text;

        if (NameSelectItem == "") return;

        var inst = GameObject.Instantiate(prefabe);
        var par = prefabe.transform.parent;
        var container = par.GetComponentInChildren<GridLayoutGroup>().gameObject;
        inst.name = NameSelectItem;
        inst.transform.SetParent(container.transform);

        inst.GetComponentInChildren<Text>().text = $"{NameSelectItem} - {slider.value}";

        var canvasGroupe = inst.GetComponent<CanvasGroup>();
        canvasGroupe.alpha = 1;
        canvasGroupe.blocksRaycasts = true;
        canvasGroupe.interactable = true;
    }

    public enum CategoryTable
    {
        tool = 1,
        human = 2,
        animal = 3,
        location = 4,
        all = 5,
        target = 6,
        task = 7,
        TAO = 8,
    }
}
