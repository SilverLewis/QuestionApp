using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHolder playerHolder;
    List<List<string[]>> questions;

    int[] ruleOrder;

    private QuestionHolder questionHolder;
    [SerializeField] private QuestionScreenUI questionScreenUI;

    //program RULES;

    private int ruleCount, kingsCount, playerCount, everyOneCount, MaxQuestions;
    private int curRound=0, curQuestion=0;

    private int dodges;

    public void Start()
    {
        questions = new List<List<string[]>>();
        questionHolder = new QuestionHolder();
        questionHolder.FillList();



        playerHolder = GameObject.Find("PlayerHolder").GetComponent<PlayerHolder>();
        TempRound();
        NextQuestion();

    }


    public void NextQuestion() {
        questionScreenUI.DisplayQuestion(curRound + 1, questions.Count, curQuestion + 1, questions[curRound].Count, questions[curRound][curQuestion][0], questions[curRound][curQuestion][1]);
        curQuestion++;
        print(questions[curRound].Count);
        if (curQuestion == questions[curRound].Count)
        {
            curQuestion = 0;
            curRound++;
        }
        if (curRound == questions.Count)
            EndGame();
    }

    public void EndGame() {
        print("GAME OVER");
    }

    private void TempRound() {
        string[] names = playerHolder.GetRandomPlayerlist();
        List<string[]> tempRound = new List<string[]>();
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] {"1"}, new string[] {},names[0]));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] {"1"}, new string[] { }, names[1]));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] {"1"}, new string[] { }, names[2]));
        questions.Add(tempRound);
        tempRound = new List<string[]>();
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "2" }, new string[] { }, names[3]));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "2" }, new string[] { }, names[4]));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "2" }, new string[] { }, names[5]));
        questions.Add(tempRound);
        tempRound = new List<string[]>();
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "3" }, new string[] { }, names[6]));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "3" }, new string[] { }, names[7]));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "3" }, new string[] { }, names[0]));
        questions.Add(tempRound);
        print("here " + questions[0][0]);
        print("here " + questions[1][1]);
        print("here " + questions[2][2]);
    }

    private void SetQuestion() {
        playerCount = playerHolder.currentPlayers;
        ruleCount = (int)Mathf.Floor(playerCount / 4);
        kingsCount = 1;
        everyOneCount = (int)Mathf.Ceil(playerCount / 4);
        MaxQuestions = playerCount + ruleCount + kingsCount + everyOneCount;
        ruleOrder = new int[ruleCount * 3];
    }


    private void RoundOne() {
        //adds rules
        List<string[]> roundOne = new List<string[]>();
        for (int i = 0; i < ruleCount; i++)
            roundOne.Add(questionHolder.GetRandomQuestion(new string[]{"1","rule"},new string[]{}));

        //adds question per person
        for (int i = 0; i < ruleCount; i++)
            roundOne.Add(questionHolder.GetRandomQuestion(new string[] { "1", "rule" }, new string[] { }));

        //adds question per person
      //  for (int i = 0; i < everyOneCount; i++)
     //       roundOne.Insert(Random.Range(2, roundOne.Count), "questionHolder.GetRandomQuestion(new string[] { "1", "rule" }, new string[] { }));

        //adds kings cup;
        roundOne.Add(questionHolder.GetRandomQuestion(new string[] { "1", "rule" }, new string[] { }));

        questions.Add(roundOne);
    }
}