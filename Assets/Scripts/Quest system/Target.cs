using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest system/ Target")]
public class Target : ScriptableObject
{
    [SerializeField] private Human customer;
    // Животное, неодушевленный объект, локация
    [SerializeField] private ScriptableObject target;
    [SerializeField] private int countTarget;
    [SerializeField] private double deadline;
}
