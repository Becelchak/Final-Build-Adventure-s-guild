using UnityEngine;
using UnityEngine.UI;

public class QuestTableView : MonoBehaviour
{
    [SerializeField] protected QuestsTable questTable;
    [SerializeField] protected GameObject prefabe;
    void Start()
    {
        foreach (var item in questTable.GetTable())
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
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowQuest(item));
        }
    }

    public void RefreshTable()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            var cell = transform.GetChild(i).gameObject;
            Destroy(cell);
        }

        foreach (var item in questTable.GetTable())
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
            inst.GetComponent<Button>().onClick.AddListener(() => buttFunc.ShowQuest(item));
        }
    }
}
