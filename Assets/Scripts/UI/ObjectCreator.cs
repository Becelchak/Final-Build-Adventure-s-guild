using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] private string typeSelect;
    [SerializeField] private CanvasGroup canvasTemp;

    public void ChangeTypeSelect(TMP_Dropdown dropdown)
    {
        typeSelect = dropdown.options[dropdown.value].text;

        switch (typeSelect)
        {
            case "Человек":
                if(canvasTemp != null)
                {
                    canvasTemp.alpha = 0f;
                    canvasTemp.interactable = false;
                    canvasTemp.blocksRaycasts = false;
                }

                var canvasGroupeHuman = GameObject.Find("CanvasHuman").GetComponent<CanvasGroup>();
                canvasGroupeHuman.alpha = 1f;
                canvasGroupeHuman.interactable = true;
                canvasGroupeHuman.blocksRaycasts = true;

                canvasTemp = canvasGroupeHuman;
                break;
            case "Животное":
                if (canvasTemp != null)
                {
                    canvasTemp.alpha = 0f;
                    canvasTemp.interactable = false;
                    canvasTemp.blocksRaycasts = false;
                }

                var canvasGroupeAnimal = GameObject.Find("CanvasAnimal").GetComponent<CanvasGroup>();
                canvasGroupeAnimal.alpha = 1f;
                canvasGroupeAnimal.interactable = true;
                canvasGroupeAnimal.blocksRaycasts = true;

                canvasTemp = canvasGroupeAnimal;
                break;
            case "Неживой объект":
                if (canvasTemp != null)
                {
                    canvasTemp.alpha = 0f;
                    canvasTemp.interactable = false;
                    canvasTemp.blocksRaycasts = false;
                }

                var canvasGroupeInanimateObject = GameObject.Find("CanvasInanimateObject").GetComponent<CanvasGroup>();
                canvasGroupeInanimateObject.alpha = 1f;
                canvasGroupeInanimateObject.interactable = true;
                canvasGroupeInanimateObject.blocksRaycasts = true;

                canvasTemp = canvasGroupeInanimateObject;
                break;
            case "Локация":
                if (canvasTemp != null)
                {
                    canvasTemp.alpha = 0f;
                    canvasTemp.interactable = false;
                    canvasTemp.blocksRaycasts = false;
                }

                var canvasGroupeLocation = GameObject.Find("CanvasLocation").GetComponent<CanvasGroup>();
                canvasGroupeLocation.alpha = 1f;
                canvasGroupeLocation.interactable = true;
                canvasGroupeLocation.blocksRaycasts = true;

                canvasTemp = canvasGroupeLocation;
                break;
            case "Угроза или возможность":
                if (canvasTemp != null)
                {
                    canvasTemp.alpha = 0f;
                    canvasTemp.interactable = false;
                    canvasTemp.blocksRaycasts = false;
                }

                var canvasTO = GameObject.Find("CanvasThreatAndOpportunity").GetComponent<CanvasGroup>();
                canvasTO.alpha = 1f;
                canvasTO.interactable = true;
                canvasTO.blocksRaycasts = true;

                canvasTemp = canvasTO;
                break;
            case "Работа (Действие)":
                if (canvasTemp != null)
                {
                    canvasTemp.alpha = 0f;
                    canvasTemp.interactable = false;
                    canvasTemp.blocksRaycasts = false;
                }

                var canvasGroupeAction = GameObject.Find("CanvasAction").GetComponent<CanvasGroup>();
                canvasGroupeAction.alpha = 1f;
                canvasGroupeAction.interactable = true;
                canvasGroupeAction.blocksRaycasts = true;

                canvasTemp = canvasGroupeAction;
                break;
            default:
                break;
        }
    }
}
