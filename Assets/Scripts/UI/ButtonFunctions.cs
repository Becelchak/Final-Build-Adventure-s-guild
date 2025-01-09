using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    ScriptableObject cellObject;

    Text name;
    Text attr1;
    Text attr2;
    Text attr3;
    Text attr4;
    Text attr5;
    Text attr6;

    private void Start()
    {
        name = GameObject.Find("Name").GetComponent<Text>();
        attr1 = GameObject.Find("Attribute 1").GetComponent<Text>();
        attr2 = GameObject.Find("Attribute 2").GetComponent<Text>();
        attr3 = GameObject.Find("Attribute 3").GetComponent<Text>();
        attr4 = GameObject.Find("Attribute 4").GetComponent<Text>();
        attr5 = GameObject.Find("Attribute 5").GetComponent<Text>();
        attr6 = GameObject.Find("Attribute 6").GetComponent<Text>();
    }

    public void ShowObject(ScriptableObject obj)
    {
        cellObject = obj;

        var strbuild = new StringBuilder();

        name.text = "";
        attr1.text = "";
        attr2.text = "";
        attr3.text = "";
        attr4.text = "";
        attr5.text = "";
        attr6.text = "";
        switch (cellObject)
        {
            case Human:
                var typeObj = (Human)cellObject;

                name.text = typeObj.GetName();
                foreach (var action in typeObj.GetActions())
                    strbuild.Append($"{action.ToString()}, \n");
                attr1.text = strbuild.ToString();
                strbuild.Clear();
                attr2.text = typeObj.GetTool();
                attr3.text = typeObj.GetRiskTool();
                attr4.text = typeObj.IsCharacter();
                foreach (var quest in typeObj.GetAvailableInQuests())
                    strbuild.Append($"{quest.ToString()}, \n");
                attr5.text = strbuild.ToString() == "" ? "" : $"Персонаж доступен в следующих квестах:{strbuild.ToString()}";
                break;

            case Animal:
                var typeObj2 = cellObject as Animal;

                name.text = typeObj2.GetName();
                foreach (var action in typeObj2.GetActions())
                    strbuild.Append($"{action.ToString()}, \n");
                attr1.text = strbuild.ToString();
                strbuild.Clear();
                attr2.text = typeObj2.GetRisk();
                break;

            //case ArtificalObject:
            //    var typeObj3 = cellObject as ArtificalObject;
            //    name.text = typeObj3.GetName();
            //    attr1.text = typeObj3.GetAction();
            //    attr2.text =  $"Коэффицент добычи {typeObj3.GetCoefficient().ToString()}";
            //    attr3.text = typeObj3.GetRisk();
            //    break;

            //case NatureObject:
            //    var typeObj4 = cellObject as NatureObject;
            //    name.text = typeObj4.GetName();
            //    attr1.text = typeObj4.GetAction();
            //    attr2.text = typeObj4.GetRisk();

            //    foreach (var location in typeObj4.GetLocations())
            //        strbuild.Append($"{location.ToString()}, \n");
            //    attr3.text = $"Можно добыть в следующих локациях: {strbuild.ToString()}";
            //    strbuild.Clear();
            //    break;

            case Action:
                var typeObj5 = cellObject as Action;
                name.text = typeObj5.GetName();
                attr2.text = $"Стандартный коэффицент добычи {typeObj5.GetCoefficient().ToString()}";

                foreach (var target in typeObj5.GetTargets())
                    strbuild.Append($"{target.ToString()}, \n");
                attr3.text = $"Объекты которые могут быть добыты этим действием: {strbuild.ToString()}";
                break;

            case InanimateObject:
                var typeObj6 = cellObject as InanimateObject;
                name.text = typeObj6.GetName();
                attr1.text = typeObj6.GetAction();
                attr2.text = typeObj6.GetNeedAction();
                attr3.text =  $"Коэффицент добычи {typeObj6.GetCoefficient().ToString()}";
                attr4.text = typeObj6.GetOpportunity();

                attr5.text = typeObj6.GetThreat();

                foreach (var location in typeObj6.GetLocations())
                    strbuild.Append($"{location.ToString()}, \n");
                attr6.text = $"Можно добыть в следующих локациях: {strbuild.ToString()}";
                strbuild.Clear();
                break;
            case Location:
                var typeObj7 = cellObject as Location;
                name.text = typeObj7.GetName();
                attr2.text = typeObj7.IsTarget();
                attr3.text = typeObj7.GetLocationsDistance();
                break;
            default:
                break;
        }
        


    }

    public void ShowQuest(ScriptableObject quest)
    {
        var questObj = (Quest)quest;
        name = GameObject.Find("QuestName").GetComponent<Text>();
        attr1 = GameObject.Find("QuestAttribute 1").GetComponent<Text>();
        attr2 = GameObject.Find("QuestAttribute 2").GetComponent<Text>();
        attr3 = GameObject.Find("QuestAttribute 3").GetComponent<Text>();
        attr4 = GameObject.Find("QuestAttribute 4").GetComponent<Text>();
        attr5 = GameObject.Find("QuestAttribute 5").GetComponent<Text>();
        attr6 = GameObject.Find("QuestAttribute 6").GetComponent<Text>();
        var attr7 = GameObject.Find("QuestAttribute 7").GetComponent<Text>();

        name.text = questObj.GetName();
        attr1.text = questObj.GetDescription();
        attr2.text = questObj.GetStringHours();
        attr3.text = questObj.GetStringLocations();
        attr4.text = questObj.GetStringTargets();
        attr5.text = questObj.GetStringTasks();
        attr6.text = questObj.GetStringTools();
        attr7.text = questObj.GetStringTAO();
    }
}
