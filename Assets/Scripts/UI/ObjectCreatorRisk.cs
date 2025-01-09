using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectCreatorRisk : MonoBehaviour
{
    [SerializeField] protected ThreatAndOpportunity SelectObject;
    [SerializeField] private ThreatAndOpportunityTable Risk;
    protected TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        var table = Risk.GetTable();
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
            SelectObject = Risk.GetObject(nameItem);
        }
        else
        {
            SelectObject = null;
        }
    }

    public ThreatAndOpportunity GiveSelectObject()
    {
        return SelectObject;
    }
}
