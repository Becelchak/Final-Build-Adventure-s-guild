using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ObjectCreatorSlots : MonoBehaviour
{
    [SerializeField] protected InanimateObject SelectObject;
    [SerializeField] private ObjectCreatorSlots ThisSlot;
    [SerializeField] private ObjectCreatorSlots OtherSlot;
    [SerializeField] private ToolsTable ToolsTable;

    //[SerializeField] private string pathFolder = "Assets/Scripts/Other/Action";
    protected TMP_Dropdown dropdown;
    //private FileInfo[] files;
    [SerializeField] protected bool slotTaken;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        //var directory = new DirectoryInfo(pathFolder);
        //files = directory.GetFiles("*.asset");
        //foreach (var file in files)
        //{
        //    var name = file.Name.Split('.')[0];
        //    dropdown.options.Add(new TMP_Dropdown.OptionData(name));
        //}

        var table = ToolsTable.GetTable();
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
            SelectObject = ToolsTable.GetObject(nameItem);
        }
        else if (SelectObject != null)
        {
            if (SelectObject.GetSlotSize() == 2 && OtherSlot.slotTaken == slotTaken && OtherSlot.SelectObject == SelectObject)
            {
                OtherSlot.SelectObject = null;
                OtherSlot.slotTaken = false;
                OtherSlot.dropdown.interactable = true;
            }
            SelectObject = null;
            slotTaken = false;
        }

        if(SelectObject != null)
        {
            switch (SelectObject.GetSlotSize())
            {
                case 1:
                    slotTaken = true;
                    if (OtherSlot.slotTaken && !OtherSlot.dropdown.interactable)
                    {
                        OtherSlot.SelectObject = null;
                        OtherSlot.slotTaken = false;
                        OtherSlot.dropdown.interactable = true;
                    }
                    break;
                case 2:
                    if (OtherSlot.slotTaken && OtherSlot.SelectObject == SelectObject)
                    {
                        slotTaken = true;
                        dropdown.value = 0;
                    }
                    else if (!OtherSlot.slotTaken)
                    {
                        slotTaken = true;
                        OtherSlot.SelectObject = SelectObject;
                        OtherSlot.slotTaken = true;
                        OtherSlot.dropdown.value = 0;
                        OtherSlot.dropdown.interactable = false;
                    }
                    else
                    {
                        SelectObject = null;
                        slotTaken = false;
                        dropdown.value = 0;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public bool GetSlotTaken()
    {
        return slotTaken;
    }

    public int GetSlotSize()
    {
        return SelectObject.GetSlotSize();
    }

    public ObjectCreatorSlots GetFirstSlot()
    {
        return ThisSlot;
    }

    public ObjectCreatorSlots GetSecondSlot()
    {
        return OtherSlot;
    }

    public InanimateObject GetSelectObject()
    {
        return SelectObject;
    }
}
