using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScreenUI : MonoBehaviour
{
    [SerializeField] private Text roundNum, question, questionNum, catagory;
    public GameManager gameManager;
    // Start is called before the first frame update
    public void DisplayQuestion(int roundNum, int maxRound, int questionNum, int maxQuestion, string question, string catagory)
    {
        this.roundNum.text = roundNum.ToString() + "/" + maxRound.ToString();
        this.questionNum.text = questionNum.ToString() + "/"+ maxQuestion.ToString();
        this.question.text = question;
        this.catagory.text = catagory.Substring(0, 1).ToUpper() + catagory.Substring(1, catagory.Length - 1);
    }

    public void NextQuestion()
    {
        gameManager.NextQuestion();
    }
}
