using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectCreatorSlotRiskNeutralizer : MonoBehaviour
{
    [SerializeField] protected InanimateObject SelectObject;
    [SerializeField] private ToolsTable RiskNeutralizerTable;
    protected TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        var table = RiskNeutralizerTable.GetTable();
        foreach (var item in table)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(item.GetName()));
        }


    }

    public void AddItemInList()
    {
        var nameItem = dropdown.options[dropdown.value].text;

        if (nameItem != "")
        {
            SelectObject = RiskNeutralizerTable.GetObject(nameItem);
        }
        else
        {
            SelectObject = null;
        }
    }
}
