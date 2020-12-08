using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GetQnA_Script : MonoBehaviour
{
    public Text questionText;

    public Text Score;
    int scoreInt = 0;

    string QnASelected;

    public Button NextQuestionBt;

    int questionInt = 0;

    public Button[] AnswerButtonArr;

    public Text[] AnwserTextArr;

    public GameObject CheckResultPanel;

    public Text CheckText;

    public Text ButtonCheckAnswerText;

    //Question
    public TextAsset easyQuestionAsset;
    List<string> QuestionList;
    List<string> GetQuestionString;
    List<string> GetAnswerString;
    List<string> RandomQuestion;

    public static List<string> ShowAnswerQuestionList = new List<string>();
    public static List<string> AllQuestionList = new List<string>();

    private void Start()
    {
        //Memory
        GetQuestionString = new List<string>();
        GetAnswerString = new List<string>();
        RandomQuestion = new List<string>();
 
        if (AddDropdown.RankSelected.ToLower() == "easy")
        {
            GetQnA(easyQuestionAsset);
            GetRandomEasyQuestionAndPrintFirstQuestion();
        }

        setTextAnswerButton();

        AllQuestionList.AddRange(QuestionList);
    }

    //get question from list
    void GetQnA(TextAsset questionList)
    {
        QuestionList = new List<string>(questionList.text.Split('\n'));
        foreach (string line in QuestionList)
        {
            string[] split = line.Split(';');
            GetQuestionString.Add(split[0]);
            GetAnswerString.Add(split[1]);
        }
    }

    //random question , print first question
    void GetRandomEasyQuestionAndPrintFirstQuestion()
    {
        for (int i = 0; i < AddDropdown.QuestionsSelected; i++)
        {
            if (!RandomQuestion.Any())
            {
                int rd = Random.Range(0, QuestionList.Count);
                RandomQuestion.Add(GetQuestionString[rd]);
            }
            else
            {
                while (true)
                {
                    bool CheckQuestion = false;
                    int rd = Random.Range(0, QuestionList.Count);
                    foreach (string question in RandomQuestion)
                    {
                        if (GetQuestionString[rd] == question)
                        {
                            CheckQuestion = true;
                            break;
                        }
                    }

                    if (!CheckQuestion)
                    {
                        RandomQuestion.Add(GetQuestionString[rd]);
                        break;
                    }
                }
            }
        }

        //Print First Question
        questionText.text = RandomQuestion[0];

        //Add question to show questionanswer list
        ShowAnswerQuestionList.AddRange(RandomQuestion);
    }

    public void CheckQuestionButton()
    {
        bool selectedQuestion = false;
        foreach(Button answerButton in AnswerButtonArr)
        {
            if (answerButton.image.color == Color.green)
            {
                selectedQuestion = true;
            }
        }
        if (selectedQuestion == true)
        {
            CheckText.text = "False";
            foreach (string qna in QuestionList)
            {
                if (QnASelected == qna)
                {
                    scoreInt++;
                    Score.text = scoreInt.ToString();
                    CheckText.text = "True";
                    break;
                }
            }
            CheckResultPanel.SetActive(true);
        }

        if (questionInt == AddDropdown.QuestionsSelected - 1)
        {
            ButtonCheckAnswerText.text = "End";
        }
    }

    public void NextQuestionButton()
    {
        questionInt++;

        CheckResultPanel.SetActive(false);

        if (questionInt == AddDropdown.QuestionsSelected)
        {
            SceneManager.LoadScene("ShowAnswerScene", LoadSceneMode.Additive);
        }

        //checkScore
        foreach (Button button in AnswerButtonArr)
        {
            button.image.color = Color.white;
        }

        //get next question
        if (questionInt <= AddDropdown.QuestionsSelected - 1)
        {
            questionText.text = RandomQuestion[questionInt];
            setTextAnswerButton();
        }
    }

    public void A_answerButton()
    {
        foreach (Button button in AnswerButtonArr)
        {
            if (button.name == "A_anserButton")
            {
                button.image.color = Color.green;
            }
            else
            {
                button.image.color = Color.white;
            }
        }

        QnASelected = questionText.text.ToString() + ";" + AnwserTextArr[0].text;

    }

    public void B_answerButton()
    {
        foreach (Button button in AnswerButtonArr)
        {
            if (button.name == "B_anserButton")
            {
                button.image.color = Color.green;
            }
            else
            {
                button.image.color = Color.white;
            }
        }

        QnASelected = questionText.text.ToString() + ";" + AnwserTextArr[1].text;
    }

    public void C_answerButton()
    {
        foreach (Button button in AnswerButtonArr)
        {
            if (button.name == "C_anserButton")
            {
                button.image.color = Color.green;
            }
            else
            {
                button.image.color = Color.white;
            }
        }

        QnASelected = questionText.text.ToString() + ";" + AnwserTextArr[2].text;
    }

    public void D_answerButton()
    {
        foreach (Button button in AnswerButtonArr)
        {
            if (button.name == "D_anserButton")
            {
                button.image.color = Color.green;
            }
            else
            {
                button.image.color = Color.white;
            }
        }

        QnASelected = questionText.text.ToString() + ";" + AnwserTextArr[3].text;
    }

    void setTextAnswerButton()
    {
        List<string> answerList = new List<string>();
        if (AddDropdown.RankSelected.ToLower() == "easy")
        {
            // get true answer
            foreach (string question in QuestionList)
            {
                string[] split = question.Split(';');
                if (questionText.text == split[0])
                {
                    answerList.Add(split[1]);
                    break;
                }
            }

            //get false answer
            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    int rd = Random.Range(0, GetAnswerString.Count);
                    bool checkAnswer = false;
                    foreach (string answer in answerList)
                    {
                        if (GetAnswerString[rd] == answer)
                        {
                            checkAnswer = true;
                            break;
                        }
                    }

                    if (checkAnswer == false)
                    {
                        answerList.Add(GetAnswerString[rd]);
                        break;
                    }
                }
            }

            //Add Answer to Text Button and random location Answer
            for (int i = 0; i < 4; i++)
            {
                int rd = Random.Range(0, answerList.Count);

                AnwserTextArr[i].text = answerList[rd];

                answerList.RemoveAt(rd);
            }
        }
    }
}
