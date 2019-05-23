using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScreenUI : MonoBehaviour
{
    [SerializeField] private Text roundNum, question, questionNum, catagory;
    // Start is called before the first frame update
    public void DisplayQuestion(int roundNum, int questionNum, string question, string catagory)
    {
        this.roundNum.text = roundNum.ToString();
        this.questionNum.text = questionNum.ToString();
        this.question.text = question;
        this.catagory.text = catagory;
    }
}
