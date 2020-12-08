using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class AddDropdown : MonoBehaviour
{
    public static string RankSelected = "Easy";
    public static int QuestionsSelected = 5;

    public Text rank;
    public Text question;

    List<string> rankString = new List<string> { "Easy", "Normal", "Hard" };
    List<string> questionString = new List<string> { "5", "6", "7", "8", "9", "10" };

    public Dropdown rankDropdown;
    public Dropdown questionsDropdown;

    private void Start()
    {
        AddItemtoDropdown();
    }

    void AddItemtoDropdown()
    {
        rankDropdown.AddOptions(rankString);
        questionsDropdown.AddOptions(questionString);
    }

    public void RankDropdownSelected(int index)
    {
        rank.text = rankString[index];
        RankSelected = rankString[index];
    }

    public void QuestionDropdownSelected(int index)
    {
        question.text = questionString[index];
        QuestionsSelected = int.Parse(questionString[index]);
    }
}
