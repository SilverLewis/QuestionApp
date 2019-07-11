using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.VisualBasic.FileIO.TextFieldParser;

public class QuestionHolder : MonoBehaviour
{

    private List<string> indexes = new List<string>();
    private List<string> question = new List<string>();
    private List<List<bool>> adjacencyMatrix = new List<List<bool>>();
    private CSVReader reader;


    void Start()
    {
        FillList();
    }

    private void AddQuestion(List<string> tags) {
        question.Add(tags[0]);
        adjacencyMatrix.Add(new List<bool>());

        for (int i = 0; i < indexes.Count; i++)
            adjacencyMatrix[adjacencyMatrix.Count-1].Add(false);

        for (int i = 1; i < tags.Count; i++)
        {
            if (!indexes.Contains(tags[i]))
            {
                indexes.Add(tags[i]);
                print("Added Tag: "+tags[i]);
                for (int j = 0; j < adjacencyMatrix.Count - 1; j++)
                    adjacencyMatrix[j].Add(false);
                adjacencyMatrix[adjacencyMatrix.Count - 1].Add(true);
            }
            else {
                int cur = indexes.IndexOf(tags[i]);
                print(cur +":"+ (adjacencyMatrix[adjacencyMatrix.Count - 1].Count)+":"+tags.Count);
                adjacencyMatrix[adjacencyMatrix.Count - 1][cur] = true;
            }
        }
    }

    public string[] GetRandomQuestion(string[] tagsTrue, string[] tagsFalse, string name) {
        string[] question = GetRandomQuestion(tagsTrue, tagsFalse);
        question[0] = ReplaceWithName(name, question[0]);
        return question;
    }

    public string[] GetRandomQuestion(string[] tagsTrue, string[] tagsFalse)
    {
        int[] idTrue = new int[tagsTrue.Length];
        int[] idFalse = new int[tagsFalse.Length];

        for (int i = 0; i < tagsTrue.Length; i++)
            idTrue[i] = indexes.IndexOf(tagsTrue[i]);
        for (int i = 0; i < tagsFalse.Length; i++)
            idFalse[i] = indexes.IndexOf(tagsFalse[i]);
        bool matches=true;
        List<int> correctQuestions= new List<int>();
        for (int i = 0; i < adjacencyMatrix.Count; i++)
        {
           
            matches = true;
            for (int j = 0; j < idTrue.Length; j++) {
                if (adjacencyMatrix[i][idTrue[j]] == false)
                        matches = false;
            }
            for (int j = 0; j < idFalse.Length; j++)
            {
                if (adjacencyMatrix[i][idFalse[j]] == true)
                    matches = false;
            }
            if (matches)
                correctQuestions.Add(i);
        }

        string[] finalQ = new string[2];

        if (correctQuestions.Count == 0)
        {
            finalQ[0] = finalQ[1] = "-1";
            return finalQ;
        }
        int q = correctQuestions[Random.Range(0, correctQuestions.Count)];
        
        finalQ[0] = question[q];
        finalQ[1] = GetGenre(adjacencyMatrix[q]);
        question.RemoveAt(q);
        adjacencyMatrix.RemoveAt(q);
        //prob return two
        return finalQ;
    }

    public string GetGenre(List<bool> tags)
    {
        for (int i = 0; i < tags.Count; i++)
            if (tags[i])
                return indexes[i];
        return "NoneFound";
    }

    public void FillList()
    {
        IndexCatagorySetUp();

        reader = GameObject.Find("PlayerHolder").GetComponent<CSVReader>();
        if (reader == null)
        {
            //create new one
            print("oopsie didnt find reader!");
        }
        
        for (int i = 0; i < reader.parsedList.Count; i++)
        {
            AddQuestion(reader.parsedList[i]);
        }
    }

    public void IndexCatagorySetUp()
    {
       indexes.Add("question");
    
    }


    //IMPORTAINT, this returns question as default if # is not in it, prob should read this propperly
    private string ReplaceWithName(string name, string question)
    {
        int nameLocation = question.IndexOf('#');
        if (nameLocation == -1)
            return question;
        return question.Substring(0, nameLocation) + name + question.Substring(nameLocation + 1, question.Length - 1 - nameLocation);

    }
}
