using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTrueAnswer : MonoBehaviour
{
    public Text QuestionText;
    public Text AnswerQuestionText;

    void Awake()
    {
        getQuestionAndAnswerText();
    }

    void getQuestionAndAnswerText()
    {
        QuestionText.text = "Question : " + GetQnA_Script.ShowAnswerQuestionList[SpawnQuestionScript.ItemLocation];

        foreach (string question in GetQnA_Script.AllQuestionList)
        {
            string[] split = question.Split(';');
            if (split[0] == GetQnA_Script.ShowAnswerQuestionList[SpawnQuestionScript.ItemLocation])
            {
                AnswerQuestionText.text = "Answer : " + split[1];
                break;
            }
        }
    }
}
