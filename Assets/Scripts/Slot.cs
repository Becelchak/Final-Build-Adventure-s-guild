using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{

    [SerializeField]
    private Text pointCellName;
    [SerializeField]
    private Transform cellContainer;
    [SerializeField]
    private GameObject cell;
    [SerializeField]
    private GameObject applyButton;
    private bool isClosed;
    private List<string> listCellText = new List<string>();


    private BrifPointJ point;
    private DragAndDrop dragAndDrop;
    private List<DragAndDrop> listAllQuestionCell = new List<DragAndDrop>();
    private List<QuestJournal> allQuestInfoInSlot = new List<QuestJournal>();
    public void OnDrop(PointerEventData eventData)
    {
        foreach (var cell in listAllQuestionCell) 
        {
            if (cell == null) return;
            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.transform.position =
               transform.position;
            }

            if (cell != null && !isClosed)
            {
                cell.SetNewContainerParent(transform.GetChild(0).transform);

                point = cell.GiveQuestInfo().brifPoint;
                cell.GetComponent<Collider2D>().enabled = false;

                applyButton.SetActive(true);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        dragAndDrop = collision.GetComponent<DragAndDrop>();
        listAllQuestionCell.Add(dragAndDrop);
        print(listAllQuestionCell.Count);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        dragAndDrop = null;
        foreach (var cell in listAllQuestionCell)
        {
            if (cell == null)
                listAllQuestionCell.Remove(cell);
        }

        print($"After remove {listAllQuestionCell.Count}");
    }

    public void ChekQuestInfo()
    {
        foreach (var itemCell in listAllQuestionCell)
        {
            if (point.ToString() == pointCellName.text && !listCellText.Contains(itemCell.GiveQuestInfo().brifPointContent))
            {
                var newCell = Instantiate(cell);
                newCell.transform.parent = cellContainer;
                newCell.name = $"Cell{cellContainer.childCount - 1}";

                newCell.GetComponentInChildren<Text>().text = itemCell.GiveQuestInfo().brifPointContent;
                listCellText.Add(itemCell.GiveQuestInfo().brifPointContent);
                newCell.SetActive(true);
                newCell.transform.localScale = Vector3.one;

                allQuestInfoInSlot.Add(itemCell.GiveQuestInfo());
                itemCell.GiveQuestInfo().SetUsed();
            }
        }
    }

    public void CloseSlot()
    {
        isClosed = true;
    }

    public List<QuestJournal> GetApplyQuestList()
    {
        return allQuestInfoInSlot;
    }
}
