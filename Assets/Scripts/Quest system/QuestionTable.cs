using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest system/ QuestionTable")]
public class QuestionTable : Table
{
    public int ID;
    public List<Question> Questions;

    public Question GetQuest(int id)
    {
        return Questions[id];
    }

    public List<Question> GetTable()
    {
        return Questions;
    }
}
