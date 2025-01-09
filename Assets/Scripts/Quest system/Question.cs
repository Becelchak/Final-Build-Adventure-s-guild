using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest system/ Question")]
public class Question : ScriptableObject
{
    public int ID;
    public string content;
    public string answer;
    public Status questionStatus;
    public BrifPoint brifPoint;
    public string brifPointContent;
    public bool isHaveSpecialList;
    public string specialListContent;
    public SerializedDictionary<string, int> tags;
    private bool isUsedInBrif;
    public string hint;

    public void SetUsed()
    {
        isUsedInBrif = true;
    }

    public bool GetUseStatus()
    {
        return isUsedInBrif;
    }
}

//public enum Status
//{
//    negative = -1,
//    netural = 0,
//    positive = 1,
//}

public enum BrifPoint
{
    None = -1,
    Target = 0,
    Location = 1,
    Resourses = 2,
    Deadline = 3,
    Quality = 4,
    Customer = 5,
    TAO = 6,
    Spesialist = 7,
}