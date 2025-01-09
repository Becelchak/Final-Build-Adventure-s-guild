using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest system/ Quest")]
public class Quest : ScriptableObject
{
    // Квесты параметры
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int hourInDay;

    // Локации квеста
    [SerializeField] private List<Location> locations = new List<Location>();

    // Персонажи квеста
    [SerializeField] private List<Human> characters = new List<Human>();

    // Цели заказчиков квеста
    [SerializeField] private List<Target> targets = new List<Target>();

    // Задачи квеста
    [SerializeField] private List<Task> tasks = new List<Task>();
    //[SerializeField] private List<Action> works = new List<Action>();

    // Инструменты квеста
    [SerializeField] private List<InanimateObject> tools = new List<InanimateObject>();

    // УВ квеста (не требуют задачи)
    [SerializeField] private List<ThreatAndOpportunity> UV = new List<ThreatAndOpportunity>();

    // Вопросы для квеста
    [SerializeField] private QuestionTable questions;

    // ??
    //[SerializeField] private string customer;
    //[SerializeField] private string target;
    //[SerializeField] private double deadline;

    public Quest(string name, string description, int hours, List<Location> locations, List<Target> targets, List<Task> tasks, List<InanimateObject> tools, List<ThreatAndOpportunity> UV, QuestionTable questions)
    {
        this.name = name;
        this.description = description;
        hourInDay = hours;
        this.locations = locations;
        this.targets = targets;
        this.tasks = tasks;
        this.tools = tools;
        this.UV = UV;
        this.questions = questions;
    }

    public string GetName()
    {
        return name;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetStringHours()
    {
        return $"Трудовой день {hourInDay} часов";
    }

    public string GetStringLocations()
    {
        var strBuild = new StringBuilder();
        foreach (var location in locations)
        {
            strBuild.Append($"{location.ToString()};");
        }
        return $"Выполняется в следующих локациях:{strBuild.ToString()}";
    }

    public string GetStringTasks()
    {
        var strBuild = new StringBuilder();
        foreach (var task in tasks)
        {
            strBuild.Append($"{task.ToString()};");
        }
        return $"Задачи в рамках квеста:{strBuild.ToString()}";
    }

    public string GetStringTargets()
    {
        var strBuild = new StringBuilder();
        foreach (var target in targets)
        {
            strBuild.Append($"{target.ToString()};");
        }
        return $"Цели в рамках квеста:{strBuild.ToString()}";
    }

    public string GetStringTools()
    {
        var strBuild = new StringBuilder();
        foreach (var tool in tools)
        {
            strBuild.Append($"{tool.ToString()};");
        }
        return $"Инструменты в рамках квеста:{strBuild.ToString()}";
    }

    public string GetStringTAO()
    {
        var strBuild = new StringBuilder();
        foreach (var itemUV in UV)
        {
            strBuild.Append($"{itemUV.ToString()};");
        }
        return $"Угрозы/возможности:{strBuild.ToString()}";
    }
}
