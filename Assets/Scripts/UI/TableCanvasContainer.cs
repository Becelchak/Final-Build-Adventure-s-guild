using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TableCanvasContainer : MonoBehaviour
{
    [SerializeField] protected HumanTable humans;
    [SerializeField] protected HumanTable characters;
    [SerializeField] protected ToolsTable tools;
    [SerializeField] protected ToolsTable toolsNeutralization;
    [SerializeField] protected LocationsTable locations;

    [SerializeField] protected GameObject prefabe;
    //[SerializeField] protected List<string> names;

    private void Start()
    {

        foreach(var item in humans.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;


            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() =>  buttFunc.ShowObject(item));
        }

        foreach (var item in characters.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }

        foreach (var item in tools.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }

        foreach (var item in toolsNeutralization.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }

        foreach (var item in locations.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }
    }

    public void RefreshTable()
    {
        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            var cell = transform.GetChild(i).gameObject;
            Destroy(cell);
        }
        foreach (var item in humans.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;


            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }

        foreach (var item in characters.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }

        foreach (var item in tools.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }

        foreach (var item in toolsNeutralization.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }

        foreach (var item in locations.GetTable())
        {
            var nameItem = item.GetName();

            var inst = GameObject.Instantiate(prefabe);
            var par = prefabe.transform.parent;
            inst.name = nameItem;
            inst.transform.SetParent(transform);

            inst.GetComponentInChildren<Text>().text = nameItem;

            var canvasGroupe = inst.GetComponent<CanvasGroup>();
            canvasGroupe.alpha = 1;
            canvasGroupe.blocksRaycasts = true;
            canvasGroupe.interactable = true;

            var buttFunc = GetComponent<ButtonFunctions>();
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowObject(item));
        }
    }
}
