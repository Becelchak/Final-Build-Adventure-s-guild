using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "QuestJournal system/ Task")]
public class Task : ScriptableObject
{
    [SerializeField] private ScriptableObject nameObject;
    [SerializeField] private bool Limited;
    [SerializeField] private int LimitedCount;

    [SerializeField] private int RequiredForQuest;
    [SerializeField] private bool FalseTarget;
}
