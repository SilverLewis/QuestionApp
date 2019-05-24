using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerHolder playerHolder;
    List<List<string>> questions;

    int[] ruleOrder;

    private QuestionHolder questionHolder;
    [SerializeField] private QuestionScreenUI questionScreenUI;

    //program RULES;

    private int ruleCount, kingsCount, playerCount, everyOneCount, MaxQuestions;
    private int curRound=0, curQuestion=0;

    public void Start()
    {

        for(int i =0;i<50;i++)
            print("RNG TEST: "+Random.Range(0, 2));
        questions = new List<List<string>>();
        questionHolder = new QuestionHolder();
        questionHolder.FillList();
        //this is per round
        /*
        playerCount = playerHolder.currentPlayers;
        ruleCount = (int)Mathf.Floor(playerCount / 4);
        kingsCount = 1;
        everyOneCount = (int)Mathf.Ceil(playerCount / 4);
        MaxQuestions = playerCount + ruleCount + kingsCount+everyOneCount;
        

        ruleOrder = new int[ruleCount*3];
        */


        playerHolder = GameObject.Find("PlayerHolder").GetComponent<PlayerHolder>();
        TempRound();
        NextQuestion();

    }


    public void NextQuestion() {
        questionScreenUI.DisplayQuestion(curRound + 1, curQuestion + 1, questions[curRound][curQuestion], "temp");
        curQuestion++;
        if (curQuestion==questions[curRound].Count)
            curRound++;
        if (curRound == questions.Count)
            EndGame();
    }

    public void EndGame() {
        print("GAME OVER");
    }


    private void TempRound() {
        List<string> tempRound = new List<string>();
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] {"1"}, new string[] {}));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] {"1"}, new string[] { }));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] {"1"}, new string[] { }));
        questions.Add(tempRound);
        tempRound = new List<string>();
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "2" }, new string[] { }));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "2" }, new string[] { }));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "2" }, new string[] { }));
        questions.Add(tempRound);
        tempRound = new List<string>();
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "3" }, new string[] { }));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "3" }, new string[] { }));
        tempRound.Add(questionHolder.GetRandomQuestion(new string[] { "3" }, new string[] { }));
        questions.Add(tempRound);
        print("here " + questions[0][0]);
        print("here " + questions[1][1]);
        print("here " + questions[2][2]);



    }




    private void RoundOne() {
        //adds rules
        List<string> roundOne = new List<string>();
        for (int i = 0; i < ruleCount; i++)
            roundOne.Add(questionHolder.GetRandomQuestion(new string[]{"1","rule"},new string[]{}));

        //adds question per person
        for (int i = 0; i < ruleCount; i++)
            roundOne.Add("player: "+questionHolder.GetRandomQuestion(new string[] { "1", "rule" }, new string[] { }));

        //adds question per person
        for (int i = 0; i < everyOneCount; i++)
            roundOne.Insert(Random.Range(2, roundOne.Count), "player: " + questionHolder.GetRandomQuestion(new string[] { "1", "rule" }, new string[] { }));

        //adds kings cup;
        roundOne.Add("player: " + questionHolder.GetRandomQuestion(new string[] { "1", "rule" }, new string[] { }));

        questions.Add(roundOne);
    }

}
